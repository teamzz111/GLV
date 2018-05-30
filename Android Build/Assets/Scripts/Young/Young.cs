using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Young : MonoBehaviour {

    public GameObject Panel;

    public TextMeshPro L;
    public TextMeshPro d;
    public TextMeshPro y;

    public static string GetValues = "";

    void Start () {
        Panel.SetActive(false);
	}
	
	void Update () {
		if(Montaje.MontajeCompleto == true && !string.IsNullOrEmpty(GetValues))
        {
            Panel.SetActive(true);
            L.text = GetValues.Split(';')[0];
            d.text = GetValues.Split(';')[1];
            y.text = GetValues.Split(';')[2];
        }
	}
}