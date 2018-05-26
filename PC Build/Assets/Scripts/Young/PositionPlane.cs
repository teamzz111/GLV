using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlane : MonoBehaviour {

    public static bool PlaneComplete = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Plane")
        {
            PlaneComplete = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Plane")
        {
            PlaneComplete = false;
        }
    }
}
