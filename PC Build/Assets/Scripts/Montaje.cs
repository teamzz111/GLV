using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montaje : MonoBehaviour {

    public GameObject Items;
    public GameObject ButtonCheck;
    public GameObject MoveControls;
    public GameObject MountedControls;
    public GameObject YoungBefore;
    public GameObject YoungAfter;

    public GameObject Plane;
    public GameObject Support1;
    public GameObject Support2;

    private bool CompleteMounting = false;

    private void Start()
    {
        MountedControls.SetActive(false);
        YoungAfter.SetActive(false);
    }

    void Update () {
		
	}

    public void Check()
    {
        if (PositionPlane.PlaneComplete == true && PositionSupport1.Support1Complete == true && PositionSupport2.Support2Complete == true && SupportCollition.LaserReady == true && SupportCollition.RackReady == true)
        {
            Items.SetActive(false);
            ButtonCheck.SetActive(false);
            MoveControls.SetActive(false);
            YoungBefore.SetActive(false);
            YoungAfter.SetActive(true);
            MountedControls.SetActive(true);
            CompleteMounting = true;
        }
        else
        {
            Debug.Log("Not ready");
        }
    }
}