using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject menu;
    public GameObject Camera;

    private bool OpenMenu = false;
    private bool DondeAnim = false;

    private Quaternion Rot;

    void Start () {
        Rot = Camera.transform.rotation;
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && (Camera.transform.rotation == Rot || Camera.transform.rotation.y == -1))
        {
            if(Camera.transform.rotation.y == 0)
            {
                Camera.GetComponent<Animation>().Play("Menu");
                OpenMenu = true;
                DondeAnim = false;
            }
            else if(Camera.transform.rotation.y == -1)
            {
                Camera.GetComponent<Animation>().Play("Resume");
                menu.GetComponent<Animation>().Play("Hide");
                OpenMenu = false;
            }
        }
        if(OpenMenu == true)
        {
            if (Camera.transform.rotation.y == -1 && DondeAnim == false)
            {
                menu.GetComponent<Animation>().Play("Show");
                DondeAnim = true;
            }
            
        }
    }
}
