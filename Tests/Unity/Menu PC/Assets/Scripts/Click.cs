using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    public AudioSource OpenSound;
    public AudioSource CloseSound;
    private bool VRConOpen = false;
    private bool VRConClose = false;
    private bool MapsOpen = false;
    private bool MapsClose = false;
    public GameObject VRConnection;
    public GameObject Menu;
    public GameObject MapsVR;
    float Stop;

    public void onClick(GameObject WhatObject)
    {
        
        Functions(WhatObject.name);
    }

    private void Functions(string name)
    {
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
        }
    }

    void Update()
    {
        if(VRConOpen == true)
        {
            if (Menu.transform.position.x >= Stop)
            {
                VRConOpen = false;
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
            }
            else
            {
                MapsVR.transform.position += new Vector3(20, 0, 0);
                VRConnection.transform.position += new Vector3(20, 0, 0);
            }
        }
    }
}
