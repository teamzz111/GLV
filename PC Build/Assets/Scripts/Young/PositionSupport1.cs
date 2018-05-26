using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSupport1 : MonoBehaviour {

    public static bool Support1Complete = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Support1")
        {
            Support1Complete = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Support1")
        {
            Support1Complete = false;
        }
    }
}
