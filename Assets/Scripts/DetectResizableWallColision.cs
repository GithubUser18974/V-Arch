using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectResizableWallColision : MonoBehaviour {

private bool ISCollideWithRoof=true;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="roof")
        ISCollideWithRoof = false;
    }
    public bool getCollision()
    {
        return ISCollideWithRoof;
    }
}
