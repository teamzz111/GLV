using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportCollition : MonoBehaviour {

    public GameObject Laser;
    public GameObject rack;

    public static bool LaserReady = false;
    public static bool RackReady = false;

    private void Start()
    {
        Laser.SetActive(false);
        rack.SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Laser" && this.gameObject.name.Equals("Support2"))
        {
            Destroy(col.gameObject);
            Laser.SetActive(true);
            LaserReady = true;
        }
        else if(col.gameObject.name == "rack" && this.gameObject.name.Equals("Support1"))
        {
            Destroy(col.gameObject);
            rack.SetActive(true);
            RackReady = true;
        }
    }
}
