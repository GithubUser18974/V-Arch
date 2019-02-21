using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDrawingGizmos : MonoBehaviour {

    public float size = .25f;
    public Color mycolor = Color.red;
    private void OnDrawGizmos()
    {
        Gizmos.color = mycolor;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
