using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMenu : MonoBehaviour {

    public GameObject VRConnection;
    public GameObject EscenariosVRn;
    
    void Start () {
        VRConnection.transform.position -= new Vector3(Screen.width, 0, 0);
        EscenariosVRn.transform.position += new Vector3(Screen.width, 0, 0);
    }
}
