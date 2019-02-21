using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour {

    private bool vShowCanvas = false;
 
    public  void mOnObjectTrigger()
    {
        Debug.Log("Trigged");
        PlayerPrefs.SetString("fob", this.gameObject.name);//Change GameObject Material
        PlayerPrefs.SetString("far", "");//Change Postion Of furniture Gameobject

        if (vShowCanvas)
        vShowCanvas = false;
        else
            vShowCanvas = true;

        PlayerPrefs.SetString("showcan", vShowCanvas.ToString());
    }

}
