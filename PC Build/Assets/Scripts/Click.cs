using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Click : MonoBehaviour {

    public AudioSource OpenSound;
    public AudioSource CloseSound;
    public GameObject VRConnection;
    public GameObject Menu;
    public GameObject MapsVR;
    public TextMeshProUGUI MessageBox;
    public Text DropdownText;

    public static string QueLab;

    private bool VRConOpen = false;
    private bool VRConClose = false;
    private bool MapsOpen = false;
    private bool MapsClose = false;
    private bool ClickDone = false;
    float Stop;

    public void onClick(GameObject WhatObject)
    {
        Functions(WhatObject.name);
    }

    public void Functions(string name)
    {
        if(ClickDone == false)
        {
            ClickDone = true;
            if (name.Equals("CloseButton"))
            {
                Application.Quit();
            }
            else if (name.Equals("VR Button"))
            {
                OpenSound.Play();
                Stop = Menu.transform.position.x * 3;
                VRConOpen = true;
            }
            else if (name.Equals("VR Back"))
            {
                CloseSound.Play();
                Stop = Menu.transform.position.x / 3;
                VRConClose = true;
            }
            else if (name.Equals("Connect Button"))
            {
                OpenSound.Play();
                Stop = MapsVR.transform.position.x / 3;
                MapsOpen = true;
            }
            else if (name.Equals("Maps Back"))
            {
                CloseSound.Play();
                Stop = MapsVR.transform.position.x * 3;
                MapsClose = true;
                TCPConPC.OnPlayCommands = "Desconnect|";
            }
            else if (name.Equals("Lloyd Button"))
            {
                QueLab = "lloydnovr";
                SceneManager.LoadScene(1);
            }
            else if (name.Equals("Young Button"))
            {
                QueLab = "youngnovr";
                SceneManager.LoadScene(1);
            }
            else if(name.Length == 10 && name.Substring(0, 9).Equals("Escenario"))
            {
                TCPConPC.OnPlayCommands = "Message|" + DropdownText;
                if (name.Equals("Escenario1")) { TCPConPC.OnPlayCommands = "Message|1"; }
                else if (name.Equals("Escenario2")) { TCPConPC.OnPlayCommands = "Message|2"; }
                else if (name.Equals("Escenario3")) { TCPConPC.OnPlayCommands = "Message|3";}
                QueLab = "youngvr";
                SceneManager.LoadScene(1);
            }
        }
    }

    void Update()
    {
        if(MessageBox.text.Equals("Iniciando sesión..."))
        {
            MessageBox.text = "sesión iniciada";
            Functions("Connect Button");
        }
        if(VRConOpen == true)
        {
            if (Menu.transform.position.x >= Stop)
            {
                VRConOpen = false;
                ClickDone = false;
            }
            else
            {
                Menu.transform.position += new Vector3(20, 0, 0);
                VRConnection.transform.position += new Vector3(20, 0, 0);
            }
        }
        else if(VRConClose == true)
        {
            if (Menu.transform.position.x <= Stop)
            {
                VRConClose = false;
                ClickDone = false;
            }
            else
            {
                Menu.transform.position -= new Vector3(20, 0, 0);
                VRConnection.transform.position -= new Vector3(20, 0, 0);
            }
        }
        else if(MapsOpen == true)
        {
            if (MapsVR.transform.position.x <= Stop)
            {
                MapsOpen = false;
                ClickDone = false;
                MessageBox.text = "";
            }
            else
            {
                MapsVR.transform.position -= new Vector3(20, 0, 0);
                VRConnection.transform.position -= new Vector3(20, 0, 0);
            }
        }
        if (MapsClose == true)
        {
            if (MapsVR.transform.position.x >= Stop)
            {
                MapsClose = false;
                ClickDone = false;
            }
            else
            {
                MapsVR.transform.position += new Vector3(20, 0, 0);
                VRConnection.transform.position += new Vector3(20, 0, 0);
            }
        }
    }
}
