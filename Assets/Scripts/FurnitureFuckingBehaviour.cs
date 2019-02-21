using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureFuckingBehaviour : MonoBehaviour {

public  void mSelectFurniture()
    {
        PlayerPrefs.SetString("far", this.gameObject.name);
        Debug.Log("Furniture Trigged");
    }
}
