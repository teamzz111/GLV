using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montaje : MonoBehaviour {

    public static bool MontajeCompleto = false;
    private static bool MontajeRealizado;

    public GameObject Young;
    public GameObject YoungAfter;

	void Start () {
        YoungAfter.SetActive(false);
	}
	
	void Update () {
        if(MontajeCompleto == true && MontajeRealizado == false)
        {
            GetItemPosition.Position.Clear();
            GetItemPosition.Rotation.Clear();
            GetItemPosition.Scale.Clear();
            Young.SetActive(false);
            YoungAfter.SetActive(true);
            MontajeRealizado = true;
        }
	}
}
