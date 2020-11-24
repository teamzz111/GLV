﻿using System;
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
    public TextMeshProUGUI ChangeResultConstant;
    public TextMeshProUGUI ChangeResultPrediction;

    public TMP_InputField  NText;
    public TMP_InputField  LambdaText;
    public TMP_InputField  mText;
    
    public GameObject LaserPrincipal;
    public GameObject Laser1A; public GameObject Pointer1A;
    public GameObject Laser1D; public GameObject Pointer1D;
    public GameObject Laser2A; public GameObject Pointer2A;
    public GameObject Laser2D; public GameObject Pointer2D;

    public Material Pointer;
    public Material PointerTop;
    public Texture PointerViolet;
    public Texture PointerBlue;
    public Texture PointerCyan;
    public Texture PointerGreen;
    public Texture PointerYellow;
    public Texture PointerOrange;
    public Texture PointerRed;
    
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

    public static string SendL;
    public static string Sendy;
    public static string Sendd;
    public static string SendChange = "0";

    private bool lambdaCorrect = false;
    private bool isYChecked = true;
    private bool isLambdaChecked = false;
    public Text ChangeResultBut;

    public GameObject lambda1;
    public GameObject lambda2;


    void Start () {
        RackPlus = Rack.transform.position.x + 2.31f;
        LasersPos = Laser1A.transform.position;
        StartAngle = Laser1A.transform.eulerAngles.z;
        lambda2.SetActive(false);
        lambda1.SetActive(false);
        lambda1.SetActive(true);
        DisableLaser();
    }
	
	void Update () {


        if (Montaje.MontajeCompleto)
        {
            L = (RackPlus - Rack.transform.position.x) * 0.2f;
            SetValueL.text = L.ToString("f3");
            if( !string.IsNullOrEmpty(LambdaText.text) && isYChecked)
            { 
                if((float)Convert.ToDouble(LambdaText.text) <= 700 && (float)Convert.ToDouble(LambdaText.text) >= 400) 
                {
                    lambdaCorrect=true;
                }
                else
                {
                    lambdaCorrect=false;
                    DisableLaser();
                }
            }
                      
              
            if (!string.IsNullOrEmpty(NText.text) && !string.IsNullOrEmpty(LambdaText.text) && !string.IsNullOrEmpty(mText.text) && lambdaCorrect)
            {
      
                try
                {
                    if (isYChecked)
                    {
                        Lambda = (float)Convert.ToDouble(LambdaText.text);
                    }
                    else if (isLambdaChecked)
                    {
                        y = (float)Convert.ToDouble(LambdaText.text);
                    }
                    else
                    {
                        MessageConsole.Message = "Seleccione el cálculo que desea realizar";
                    }
                    try
                    {
                        N = (float)Convert.ToDouble(NText.text);
                        d = 0.001f / N;
                        try
                        {
                            m = (float)Convert.ToDouble(mText.text);
                            
                            SetValued.text = d.ToString();

                            if (isYChecked)
                            {
                             
                                    y = (m * (Lambda / 1000000000f) * L) / d;
                                    SetValuey.text = y.ToString("f4");
                            }
                            else if (isLambdaChecked)
                            {
                                Lambda = (d * y) / (m * L);
                                Lambda = Lambda / 0.000000001f;
                                SetValuey.text = Lambda.ToString("f2");
                            }
                            else
                            {
                                MessageConsole.Message = "Seleccione el cálculo que desea realizar";
                            }
                            SendL = SetValueL.text;
                            Sendy = SetValuey.text;
                            Sendd = SetValued.text;
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
                                DisableLaser();
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
                            DisableLaser();
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
                        DisableLaser();
                    }
                    MessageConsole.Message = "Escriba un carácter válido!";
                }
            }
            else
            {
                DisableLaser();
            }
        }
	}

    public void ChangeButAction()
    {
        if (ChangeResultBut.text.Equals("Z"))
        {
            SendChange = "1";
            SetValuey.text = "0";
            LambdaText.text = "";
            ChangeResultBut.text = "Lambda";
            isYChecked = false;
            isLambdaChecked = true;
            ChangeResultConstant.text = "Z";
            ChangeResultPrediction.text = "Lambda(    )";
            lambda1.SetActive(false);
            lambda2.SetActive(true);
        }
        else if (ChangeResultBut.text.Equals("Lambda"))
        {
            SendChange = "0";
            SetValuey.text = "0";
            LambdaText.text = "";
            ChangeResultBut.text = "Z";
            isYChecked = true;
            isLambdaChecked = false;
            ChangeResultConstant.text = "Lambda(    )";
            ChangeResultPrediction.text = "Z";
            lambda2.SetActive(false);
            lambda1.SetActive(true);
        }
        
    }
    
    private void DisableLaser()
    {
        LaserPrincipal.SetActive(false);
        Laser1A.SetActive(false); Pointer1A.SetActive(false);
        Laser1D.SetActive(false); Pointer1D.SetActive(false);
        Laser2A.SetActive(false); Pointer2A.SetActive(false);
        Laser2D.SetActive(false); Pointer2D.SetActive(false);
        PointerTop.color = Color.red;
        Pointer.mainTexture = PointerRed;
    }

    private void MakeLaser()
    {
        if (Lambda < 440){ Pointer.mainTexture = PointerViolet; PointerTop.color = new Color32(140,0,255,1); }
        else if (Lambda >= 440 && Lambda < 485) { Pointer.mainTexture = PointerBlue; PointerTop.color = Color.blue; }
        else if (Lambda >= 485 && Lambda < 500) { Pointer.mainTexture = PointerCyan; PointerTop.color = Color.cyan; }
        else if (Lambda >= 500 && Lambda < 565) { Pointer.mainTexture = PointerGreen; PointerTop.color = Color.green; }
        else if (Lambda >= 565 && Lambda < 590) { Pointer.mainTexture = PointerYellow; PointerTop.color = Color.yellow; }
        else if (Lambda >= 590 && Lambda < 600) { Pointer.mainTexture = PointerOrange; PointerTop.color = new Color32(255, 127, 0,1); }
        else if (Lambda >= 600) { Pointer.mainTexture = PointerOrange; PointerTop.color = new Color32(255, 127, 0, 1); }

        LaserPrincipal.SetActive(true);
        Laser1A.SetActive(true);
        Laser1D.SetActive(true);
        Laser2A.SetActive(true);
        Laser2D.SetActive(true);

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
