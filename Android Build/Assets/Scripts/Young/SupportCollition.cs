using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportCollition : MonoBehaviour {

    public GameObject LaserFake;
    public GameObject Laser;
    public GameObject RackFake;
    public GameObject Rack;

    public static string NewCollition;

    void Start () {
        LaserFake.SetActive(false);
        RackFake.SetActive(false);
	}
    
    void Update()
    {
        if (!string.IsNullOrEmpty(NewCollition))
        {
            Collition(NewCollition);
            NewCollition = "";
        }
    }
    public void Collition(string obj)
    {
        if (obj.Equals("Support1"))
        {
            Rack.SetActive(false);
            RackFake.SetActive(true);
        }
        else if (obj.Equals("Support2"))
        {
            Laser.SetActive(false);
            LaserFake.SetActive(true);
        }
    }
}
