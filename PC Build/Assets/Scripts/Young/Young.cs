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

    public GameObject Laser1A; public GameObject Pointer1A;
    public GameObject Laser1D; public GameObject Pointer1D;
    public GameObject Laser2A; public GameObject Pointer2A;
    public GameObject Laser2D; public GameObject Pointer2D;

    private float RackPlus;
    private float RackCenter;

    private float Lambda;
    private float N;
    private float m;
    private float L;
    private float d;
    private float y;

    private Vector3 LasersPos;
    private float LaserLenght;
    private float Angle;
    private float MiddlePos;
    private float StartAngle;
    private float ExtraLaserX;
    private float ExtraLaserY;

    void Start () {
        RackPlus = Rack.transform.position.x + 2.31f;
        LasersPos = Laser1A.transform.position;
        StartAngle = Laser1A.transform.eulerAngles.z;
    }
	
	void Update () {
        if (Montaje.MontajeCompleto)
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
                            y = (m * Lambda * L) / d;
                            SetValuey.text = y.ToString("f4");
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

        y = y / 0.2f;

        Pointer1A.transform.position = new Vector3(RackPlus - 0.06f, LasersPos.y + y - 0.02f, LasersPos.z);
        Pointer1D.transform.position = new Vector3(RackPlus - 0.06f, LasersPos.y - y - 0.02f, LasersPos.z);

        LaserLenght = ((float)Math.Sqrt(Math.Pow(y, 2) + Math.Pow((RackPlus - RackCenter), 2))) / 2f;
        Angle = (float)Math.Asin(y / (LaserLenght * 2));
        MiddlePos = RackPlus - ((RackPlus - RackCenter) / 2f);

        if(y >= 0.9)
        {
            Pointer1A.SetActive(false);
            Pointer1D.SetActive(false);
            ExtraLaserX = 10 * (float)Math.Cos(Angle);
            ExtraLaserY = 10 * (float)Math.Sin(Angle);
            Laser1A.transform.localScale = new Vector3(0.03f, 5, 0.03f);
            Laser1A.transform.position = new Vector3(RackCenter + (ExtraLaserX / 2), LasersPos.y + (ExtraLaserY / 2), LasersPos.z);
        }
        else
        {
            Pointer1A.SetActive(true);
            Pointer1D.SetActive(true);
            Laser1A.transform.localScale = new Vector3(0.03f, LaserLenght, 0.03f);
            Laser1A.transform.position = new Vector3(MiddlePos, LasersPos.y + (y / 2), LasersPos.z);
        }
        Laser1A.transform.eulerAngles = new Vector3(0, 0, StartAngle + (Angle * (180f / (float)Math.PI)));
        Laser1D.transform.localScale = new Vector3(0.03f, LaserLenght, 0.03f);
        Laser1D.transform.eulerAngles = new Vector3(0, 0, StartAngle - (Angle * (180f / (float)Math.PI)));
        Laser1D.transform.position = new Vector3(MiddlePos, LasersPos.y - (y / 2), LasersPos.z);

        y = 2 * y;

        Pointer2A.transform.position = new Vector3(RackPlus - 0.06f, LasersPos.y + y - 0.02f, LasersPos.z);
        Pointer2D.transform.position = new Vector3(RackPlus - 0.06f, LasersPos.y - y - 0.02f, LasersPos.z);

        LaserLenght = ((float)Math.Sqrt(Math.Pow(y, 2) + Math.Pow((RackPlus - RackCenter), 2))) / 2f;
        Angle = (float)Math.Asin(y / (LaserLenght * 2));
        MiddlePos = RackPlus - ((RackPlus - RackCenter) / 2f);

        if (y >= 0.9)
        {
            Pointer2A.SetActive(false);
            Pointer2D.SetActive(false);
            ExtraLaserX = 10 * (float)Math.Cos(Angle);
            ExtraLaserY = 10 * (float)Math.Sin(Angle);
            Laser2A.transform.localScale = new Vector3(0.03f, 5, 0.03f);
            Laser2A.transform.position = new Vector3(RackCenter + (ExtraLaserX / 2), LasersPos.y + (ExtraLaserY / 2), LasersPos.z);
        }
        else
        {
            Pointer2A.SetActive(true);
            Pointer2D.SetActive(true);
            Laser2A.transform.localScale = new Vector3(0.03f, LaserLenght, 0.03f);
            Laser2A.transform.position = new Vector3(MiddlePos, LasersPos.y + (y / 2), LasersPos.z);
        }
        Laser2A.transform.eulerAngles = new Vector3(0, 0, StartAngle + (Angle * (180f / (float)Math.PI)));
        Laser2D.transform.localScale = new Vector3(0.03f, LaserLenght, 0.03f);
        Laser2D.transform.eulerAngles = new Vector3(0, 0, StartAngle - (Angle * (180f / (float)Math.PI)));
        Laser2D.transform.position = new Vector3(MiddlePos, LasersPos.y - (y / 2), LasersPos.z);
    }
}
