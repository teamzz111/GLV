using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendYoungPosition : MonoBehaviour {

    public GameObject Laser;
    public GameObject Rack;
    public GameObject Support1;
    public GameObject Support2;
    public GameObject Plane;

    private Vector3 LaserPos;
    private Vector3 RackPos;
    private Vector3 Support1Pos;
    private Vector3 Support2Pos;
    private Vector3 PlanePos;

    private Vector3 LaserRot;
    private Vector3 RackRot;
    private Vector3 Support1Rot;
    private Vector3 Support2Rot;
    private Vector3 PlaneRot;

    public GameObject MountedSupport;
    public GameObject Laser1A;
    public GameObject Laser1APointer;
    public GameObject Laser1D;
    public GameObject Laser1DPointer;
    public GameObject Laser2A;
    public GameObject Laser2APointer;
    public GameObject Laser2D;
    public GameObject Laser2DPointer;

    private void Start()
    {
        if(QueLab.VR == true)
        {
            StartCoroutine(StartTimer(0));
        }
    }

    public IEnumerator StartTimer(int CountdownValue)
    {
        while (true)
        {
            if(Montaje.MontajeCompleto == false)
            {
                SendValues();
            }
            else
            {
                SendValuesMounted();
                SendPrediction();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void SendValues() {
        TCPConPC.OnPlayCommands.Add("Position|0" + Laser.transform.position.ToString("f1") + ";1" + Plane.transform.position.ToString("f1") + ";2" + Rack.transform.position.ToString("f1") + ";3" + Support1.transform.position.ToString("f1") + ";4" + Support2.transform.position.ToString("f1"));
        TCPConPC.OnPlayCommands.Add("Rotation|0" + Laser.transform.eulerAngles.ToString() + ";1" + Plane.transform.eulerAngles.ToString() + ";2" + Rack.transform.eulerAngles.ToString() + ";3" + Support1.transform.eulerAngles.ToString() + ";4" + Support2.transform.eulerAngles.ToString());
    }

    private void SendValuesMounted()
    {
        TCPConPC.OnPlayCommands.Add("Position|0" + MountedSupport.transform.position.ToString("f1") + ";1" + Laser1A.transform.position.ToString("f1") + ";2" + Laser1D.transform.position.ToString("f1") + ";3" + Laser2A.transform.position.ToString("f1") + ";4" + Laser2D.transform.position.ToString("f1"));
        TCPConPC.OnPlayCommands.Add("Rotation|0" + MountedSupport.transform.eulerAngles.ToString() + ";1" + Laser1A.transform.eulerAngles.ToString() + ";2" + Laser1D.transform.eulerAngles.ToString() + ";3" + Laser2A.transform.eulerAngles.ToString() + ";4" + Laser2D.transform.eulerAngles.ToString());
        TCPConPC.OnPlayCommands.Add("Scale|0" + MountedSupport.transform.localScale.ToString("f1") + ";1" + Laser1A.transform.localScale.ToString("f1") + ";2" + Laser1D.transform.localScale.ToString("f1") + ";3" + Laser2A.transform.localScale.ToString("f1") + ";4" + Laser2D.transform.localScale.ToString("f1"));
    }

    private void SendPrediction()
    {
        if(!string.IsNullOrEmpty(Young.SendL) && !string.IsNullOrEmpty(Young.Sendd) && !string.IsNullOrEmpty(Young.Sendy)){
            TCPConPC.OnPlayCommands.Add("Prediction|" + Young.SendL + ";" + Young.Sendd + ";" + Young.Sendy);
        }
    }
}
