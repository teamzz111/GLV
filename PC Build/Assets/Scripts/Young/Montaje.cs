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
    public GameObject PredictionPanel;
    public GameObject ValuesPanel;

    public GameObject Plane;
    public GameObject Support1;
    public GameObject Support2;

    public static bool MontajeCompleto = false;

    private void Start()
    {
        MountedControls.SetActive(false);
        YoungAfter.SetActive(false);
        PredictionPanel.SetActive(false);
        ValuesPanel.SetActive(false);
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
            if(QueLab.VR == false)
            {
                PredictionPanel.SetActive(true);
            }
            ValuesPanel.SetActive(true);
            MontajeCompleto = true;
            MessageConsole.Message = "Montaje completado!, Ahora establezca las constantes";
        }
        else
        {
            MessageConsole.Message = "El montaje no es correcto!";
        }
    }
}