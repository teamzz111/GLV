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

    public TextMeshPro ChangeText;

    public static string GetValues = "";

    void Start () {
        Panel.SetActive(false);
	}
	
	void Update () {
		if(Montaje.MontajeCompleto == true && !string.IsNullOrEmpty(GetValues))
        {
            Panel.SetActive(true);
            if (GetValues.Split(';')[0].Equals("0"))
            {
                ChangeText.text = "y(m)";
            }
            else if (GetValues.Split(';')[0].Equals("1"))
            {
                ChangeText.text = "Lambda\n(nm)";
            }
            L.text = GetValues.Split(';')[1];
            d.text = GetValues.Split(';')[2];
            y.text = GetValues.Split(';')[3];
        }
	}
}