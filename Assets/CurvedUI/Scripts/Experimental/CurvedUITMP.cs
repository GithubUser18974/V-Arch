﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

#if CURVEDUI_TMP 
using TMPro;
#endif 

//To use this class you have to add CURVEDUI_TMP to your define symbols. You can do it in project settings.
//To learn how to do it visit http://docs.unity3d.com/Manual/PlatformDependentCompilation.html and search for "Platform Custom Defines"
namespace CurvedUI
{
    [ExecuteInEditMode]
    public class CurvedUITMP : MonoBehaviour
    {

#if CURVEDUI_TMP

        //internal
        CurvedUIVertexEffect crvdVE;
        TextMeshProUGUI tmp;
        CurvedUISettings mySettings;
        Mesh savedMesh;
        VertexHelper vh;

        Vector2 savedSize;
        Vector3 savedUp;
        Vector3 savedPos;
        List<CurvedUITMPSubmesh> subMeshes = new List<CurvedUITMPSubmesh>(); 

        [HideInInspector]
        public bool Dirty = false; // set this to true to force mesh update.

        bool curvingRequired = false;
        bool tesselationRequired = false;

        void FindTMP()
        {
            if (this.GetComponent<TextMeshProUGUI>() != null)
            {
                tmp = this.gameObject.GetComponent<TextMeshProUGUI>();
                crvdVE = this.gameObject.GetComponent<CurvedUIVertexEffect>();
                mySettings = GetComponentInParent<CurvedUISettings>();
                transform.hasChanged = false;

                FindSubmeshes();
            }
        }

        void FindSubmeshes()
        {
            foreach (TMP_SubMeshUI sub in GetComponentsInChildren<TMP_SubMeshUI>())
            {
                CurvedUITMPSubmesh msh = sub.gameObject.AddComponentIfMissing<CurvedUITMPSubmesh>();
                if(!subMeshes.Contains(msh))
                    subMeshes.Add(msh);
            }
        }

        void OnEnable()
        {

            FindTMP();

            if (tmp != null)
                tmp.RegisterDirtyMaterialCallback(TesselationRequiredCallback);
        }

        void OnDisable()
        {
            if (tmp != null)
                tmp.UnregisterDirtyMaterialCallback(TesselationRequiredCallback);
        }


        void TesselationRequiredCallback()
        {
            tesselationRequired = true;
            curvingRequired = true;
        }


        void LateUpdate()
        {

            //Edit Mesh on TextMeshPro component
            if (tmp != null)
            {

                if (tmp.havePropertiesChanged)
                {
                    tesselationRequired = true;
                    // Debug.Log("prop changed");
                }
                else if (savedSize != (transform as RectTransform).rect.size)
                {
                    tesselationRequired = true;
                    //Debug.Log("size changed");

                }
                else if (!savedPos.AlmostEqual(mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(transform.position)))
                {
                    curvingRequired = true;
                    // Debug.Log("pos changed");

                }
                else if (!savedUp.AlmostEqual(mySettings.transform.worldToLocalMatrix.MultiplyVector(transform.up)))
                {
                    curvingRequired = true;
                    // Debug.Log("up changed");

                }


                if (Dirty || tesselationRequired || savedMesh == null || vh == null || (curvingRequired && !Application.isPlaying))
                {
                    //Modify the mesh
                    //Debug.Log("meshing TMP");
                    tmp.renderMode = TMPro.TextRenderFlags.Render;
                    tmp.ForceMeshUpdate();
                    vh = new VertexHelper(tmp.mesh);
                    crvdVE.TesselationRequired = true;
#if UNITY_5_1
				    crvdVE.ModifyMesh(vh.GetUIVertexStream);
#else
                    crvdVE.ModifyMesh(vh);
#endif


                    //upload mesh to TMP Object
                    savedMesh = new Mesh();
                    vh.FillMesh(savedMesh);
                    tmp.renderMode = TMPro.TextRenderFlags.DontRender;

                    //reset flags
                    tesselationRequired = false;
                    Dirty = false;

                    //save current data
                    savedSize = (transform as RectTransform).rect.size;
                    savedUp = mySettings.transform.worldToLocalMatrix.MultiplyVector(transform.up);
                    savedPos = mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(transform.position);

                    //prompt submeshes to update
                    FindSubmeshes();
                    foreach (CurvedUITMPSubmesh mesh in subMeshes)
                        mesh.UpdateSubmesh(true, false);
                }


                if (curvingRequired)
                {
                    // Debug.Log("curving TMP");
                    crvdVE.TesselationRequired = false;
                    crvdVE.CurvingRequired = true;

#if UNITY_5_1
                    crvdVE.ModifyMesh(vh.GetUIVertexStream);
#else
                    crvdVE.ModifyMesh(vh);
#endif
                    //fill mesh to VertexHelper
                    vh.FillMesh(savedMesh);

                    //reset flags
                    curvingRequired = false;

                    //save current data
                    savedSize = (transform as RectTransform).rect.size;
                    savedUp = mySettings.transform.worldToLocalMatrix.MultiplyVector(transform.up);
                    savedPos = mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(transform.position);

                    //prompt submeshes to update
                    foreach (CurvedUITMPSubmesh mesh in subMeshes)
                        mesh.UpdateSubmesh(false, true);
                }

                tmp.canvasRenderer.SetMesh(savedMesh);

            }
            else {
                FindTMP();
            }
        }

#endif
    }
}



