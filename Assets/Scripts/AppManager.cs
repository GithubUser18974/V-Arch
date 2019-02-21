using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour {
    private CharacterController CC;
    private Transform VrHead;
    public float Speed = .1f;
    private bool CouldMove = false;
    public Text Vt;
    private GameObject vPlayer;
    private float vMoveRatio = 0.1f;
    // Use this for initialization
    void Start () {
        vPlayer = GameObject.FindGameObjectWithTag("Player");
        CC = vPlayer.gameObject.GetComponent<CharacterController>();
        VrHead = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        /////////////////////////////////////////////////////////       Test Code
        for(int i = 1; i < 5; i++)
        {
            if (Input.GetButtonDown("Fire" + i))
            {
                Vt.text = "Fire " + i;
            }
            else if (Input.GetButtonDown("Interact"))
            {
                Vt.text = "Interact " + i;
            }
        }
        if (Input.GetButtonDown("LeftVRTriggerAxis"))
        {
            Vt.text = "LeftVRTriggerAxis " ;
        }

        if (Input.GetButtonDown("Interact"))
        {
            Vt.text = "Interact ";
        }
        ////////////////////////////////////////////////        End Of Test Code

       
        if (Input.GetButtonDown("Fire1"))
        {
            if(vMoveRatio>0)
            vMoveRatio *= -1;
            if (PlayerPrefs.GetString("far") != null || PlayerPrefs.GetString("far") != "") { mRelocateObject_Z(); }
                

        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (vMoveRatio < 0)
                vMoveRatio *= -1;
            if (PlayerPrefs.GetString("far") != null || PlayerPrefs.GetString("far") != "") { mRelocateObject_X(); }
               
        }
        else if (Input.GetButtonDown("Fire3"))

        {
            if (vMoveRatio > 0)
                vMoveRatio *= -1;
            if (PlayerPrefs.GetString("far") != null || PlayerPrefs.GetString("far") != "") { mRelocateObject_X(); }
            if (CouldMove) { CouldMove = false; } else { CouldMove = true; }
        }

        else if (Input.GetButtonDown("Fire4"))
        {
            if (vMoveRatio < 0)
                vMoveRatio *= -1;
            if (PlayerPrefs.GetString("far") != null || PlayerPrefs.GetString("far") != "") { mRelocateObject_Z(); }
                
        }

         if (Input.GetButtonDown("Camera Y") || Input.GetButtonDown("Camera X")||Input.GetKey(KeyCode.Space))

        {
            if (CouldMove) { CouldMove = false; } else { CouldMove = true; }
        }

        if (CouldMove)
        {
            Vector3 forw = VrHead.TransformDirection(Vector3.forward);
            CC.SimpleMove(forw * Speed);
        }
	}
    private  void mRelocateObject_X()
    {
        GameObject vObj = GameObject.Find(PlayerPrefs.GetString("far"));
        if ((PlayerPrefs.GetString("far") != null || PlayerPrefs.GetString("far") != "") && vObj != null)
        {
           
            vObj.transform.localPosition = new Vector3(vObj.transform.position.x + vMoveRatio, 0, vObj.transform.position.z);
        }
    }
    private void mRelocateObject_Z()
    {
     
        GameObject vObj = GameObject.Find(PlayerPrefs.GetString("far"));
        if ((PlayerPrefs.GetString("far") != null || PlayerPrefs.GetString("far") != "") && vObj != null)
        {
            
            vObj.transform.localPosition = new Vector3(vObj.transform.position.x , 0, vObj.transform.position.z + vMoveRatio);
        }
    }
}
