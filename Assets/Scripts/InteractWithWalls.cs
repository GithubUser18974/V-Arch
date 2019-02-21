using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithWalls : MonoBehaviour {
    private GameObject vObjectToReturn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void WhenObjectSelected()
    {
        Debug.Log("Item Selected ");
        vObjectToReturn = this.gameObject;
    }
    public GameObject TheSelectedObject()
    {
        return vObjectToReturn;
    }
}
