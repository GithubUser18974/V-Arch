using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizableObject : MonoBehaviour {
    public GameObject vResizableObject;
    public GameObject vBackLeftUp;
    public GameObject vFrontLeftUp;
    public GameObject vBackRightUp;
    public GameObject vBackLeftDown;
    public float vScale = 0.1f;
    private bool CouldScaleinY=true;
    public DetectResizableWallColision detectResizableWallColision;
	// Update is called once per frame
	void Update () {
        CouldScaleinY = detectResizableWallColision.getCollision();
       
        //XBack
        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.RightArrow))
        {
            vResizableObject.transform.SetParent(vBackLeftUp.transform);
            vBackLeftUp.transform.localScale += new Vector3(vScale, 0, 0);

        }
        //XFront
        else if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftArrow))
        {
            vResizableObject.transform.SetParent(vFrontLeftUp.transform);
            vFrontLeftUp.transform.localScale += new Vector3(vScale, 0, 0);
        }
        //ZLeft
        else if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftArrow))
        {
            vResizableObject.transform.SetParent(vBackLeftUp.transform);
            vBackLeftUp.transform.localScale += new Vector3(0, 0, vScale);
        }
        //ZRight
        else if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.RightArrow))
        {
            vResizableObject.transform.SetParent(vBackRightUp.transform);
            vBackRightUp.transform.localScale += new Vector3(0, 0, vScale);
        }
        //YUP
        else if (Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.RightArrow)&&CouldScaleinY)
        {
            vResizableObject.transform.SetParent(vFrontLeftUp.transform);
            vFrontLeftUp.transform.localScale += new Vector3(0, vScale, 0);

        }
        //YDown
        else if (Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.LeftArrow))
        {
            vResizableObject.transform.SetParent(vBackLeftDown.transform);
            vBackLeftDown.transform.localScale += new Vector3(0, vScale, 0);
            CouldScaleinY = true;

        }
    }
}
