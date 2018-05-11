using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject menu;
    public GameObject Camera;

    private bool OpenMenu = false;

    void Start () {
        menu.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if(menu.transform.rotation.y == 0)
            {
                Camera.GetComponent<Animation>().Play("Menu");
            }
            else if(menu.transform.rotation.y == 180)
            {
                Camera.GetComponent<Animation>().Play("Resume");
            }
            OpenMenu = true;
        }
        if(OpenMenu == true)
        {
            if(menu.transform.rotation.y == 180)
            {
                menu.SetActive(true);
                OpenMenu = false;
            }
            else if (menu.transform.rotation.y == 0)
            {
                menu.SetActive(false);
                OpenMenu = false;
            }
        }
    }
}
