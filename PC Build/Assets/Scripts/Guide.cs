using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour {

    private bool Open = false;
    private GameObject guide;

    void Start()
    {
        guide = this.gameObject;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.G) && QueLab.VR == false) {
            if(Open == false && Convert.ToInt32(guide.transform.rotation.eulerAngles.x) == 90)
            {
                Open = true;
                guide.GetComponent<Animation>().Play("Show");
            }
            else if (Open == true && Convert.ToInt32(guide.transform.rotation.eulerAngles.x) == 0)
            {
                Open = false;
                guide.GetComponent<Animation>().Play("Hide");
            }
        }

    }
}
