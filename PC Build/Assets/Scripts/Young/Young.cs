using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Young : MonoBehaviour {

    public GameObject Rack;
    public TextMeshProUGUI SetValueL;
    public TextMeshProUGUI SetValued;
    public TextMeshProUGUI SetValuey;

    public InputField NText;
    public InputField LambdaText;
    public InputField mText;

    public GameObject Laser1;

    private float RackPlus;
    private float RackMinus;
    private float RackCenter;

    private float Lambda;
    private float N;
    private float m;
    private float L;
    private float d;

    private Vector3 Laser1Pos;
    private float Laser1Lenght;

    void Start () {
        RackPlus = Rack.transform.position.x + 2.31f;
        RackMinus = Rack.transform.position.x - 2f;
        Laser1Pos = Laser1.transform.position;
    }
	
	void Update () {
        if (!Montaje.MontajeCompleto)
        {
            L = (RackPlus - Rack.transform.position.x) * 0.2f;
            SetValueL.text = L.ToString("f3");
            if (!string.IsNullOrEmpty(NText.text) && !string.IsNullOrEmpty(LambdaText.text) && !string.IsNullOrEmpty(mText.text))
            {
                try
                {
                    Lambda = (float)Convert.ToDouble(LambdaText.text) / 1000000000f;
                    try
                    {
                        N = (float)Convert.ToDouble(NText.text);
                        d = 0.001f / N;
                        try
                        {
                            m = (float)Convert.ToDouble(mText.text);
                            
                            SetValued.text = d.ToString();
                            SetValuey.text = ((m * Lambda * L) / d).ToString("f4");
                            MakeLaser();
                        }
                        catch
                        {
                            if (mText.text.Length >= 2)
                            {
                                mText.text = mText.text.Remove(mText.text.Length - 1);
                            }
                            else
                            {
                                mText.text = "";
                            }
                            MessageConsole.Message = "Escriba un carácter válido!";
                        }
                    }
                    catch
                    {
                        if (NText.text.Length >= 2)
                        {
                            NText.text = NText.text.Remove(NText.text.Length - 1);
                        }
                        else
                        {
                            NText.text = "";
                        }
                        MessageConsole.Message = "Escriba un carácter válido!";
                    }
                }
                catch
                {
                    if (LambdaText.text.Length >= 2)
                    {
                        LambdaText.text = LambdaText.text.Remove(LambdaText.text.Length - 1);
                    }
                    else
                    {
                        LambdaText.text = "";
                    }
                    MessageConsole.Message = "Escriba un carácter válido!";
                }
            }
        }
	}

    private void MakeLaser()
    {
        RackCenter = Rack.transform.position.x - 0.07f;
        Laser1Lenght = (RackCenter - RackMinus) / 2f;
        Laser1.transform.position = new Vector3(RackCenter - Laser1Lenght, Laser1Pos.y, Laser1Pos.z);
        Laser1.transform.localScale = new Vector3(0.03f, Laser1Lenght, 0.03f);
    }
}
