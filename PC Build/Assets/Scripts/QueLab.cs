using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueLab : MonoBehaviour {

    public GameObject YoungMaterials;
    public GameObject LloydMaterials;

	void Start () {
        if (Click.QueLab.Equals("young"))
        {
            YoungMaterials.SetActive(true);
        }
        else if (Click.QueLab.Equals("lloid"))
        {
            LloydMaterials.SetActive(true);
        }
	}
	
	void Update () {
		
	}
}
