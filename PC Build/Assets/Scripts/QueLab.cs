using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueLab : MonoBehaviour {

    public GameObject YoungMaterials;

    public static bool VR = false;

    void Start () {
        if (Click.QueLab.Equals("youngnovr"))
        {
            YoungMaterials.SetActive(true);
            VR = false;
        }
        else if(Click.QueLab.Equals("youngvr")){
            YoungMaterials.SetActive(true);
            VR = true;
        }
	}
}
