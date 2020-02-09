using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSupport2 : MonoBehaviour {

    public static bool Support2Complete = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Support2")
        {
            Support2Complete = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Support2")
        {
            Support2Complete = false;
        }
    }
}
