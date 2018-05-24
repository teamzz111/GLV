using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueLab : MonoBehaviour {

    public GameObject YoungMaterials;
    public GameObject YoungMaterialsAfter;

    void Start () {
        if (Click.QueLab.Equals("young"))
        {
            YoungMaterials.SetActive(true);
            YoungMaterialsAfter.SetActive(true);
        }
	}
}
