using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItems : MonoBehaviour {

    private GameObject WhatObject;
    private GameObject FrameLaser;
    private GameObject Framerack;
    private GameObject FramePlane;
    private GameObject FrameSupport1;
    private GameObject FrameSupport2;

    void Start()
    {
        FrameLaser = GameObject.FindGameObjectWithTag("FrameLaser"); FrameLaser.SetActive(false);
        Framerack = GameObject.FindGameObjectWithTag("Framerack"); Framerack.SetActive(false);
        FramePlane = GameObject.FindGameObjectWithTag("FramePlane"); FramePlane.SetActive(false);
        FrameSupport1 = GameObject.FindGameObjectWithTag("FrameSupport1"); FrameSupport1.SetActive(false);
        FrameSupport2 = GameObject.FindGameObjectWithTag("FrameSupport2"); FrameSupport2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && MoveControls.AnyControl == true && ResultTable.TableOpen == false)
        {
            Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;

            if (Physics.Raycast(mouseray, out rayhit, 100.0f))
            {
                if (rayhit.transform.name.Equals("Laser"))
                {
                    WhatObject = GameObject.FindGameObjectWithTag(rayhit.transform.name);
                    FrameLaser.SetActive(true);
                    Framerack.SetActive(false);
                    FramePlane.SetActive(false);
                    FrameSupport1.SetActive(false);
                    FrameSupport2.SetActive(false);

                }
                else if (rayhit.transform.name.Equals("rack"))
                {
                    WhatObject = GameObject.FindGameObjectWithTag(rayhit.transform.name);
                    FrameLaser.SetActive(false);
                    Framerack.SetActive(true);
                    FramePlane.SetActive(false);
                    FrameSupport1.SetActive(false);
                    FrameSupport2.SetActive(false);
                }
                else if (rayhit.transform.name.Equals("Plane"))
                {
                    WhatObject = GameObject.FindGameObjectWithTag(rayhit.transform.name);
                    FrameLaser.SetActive(false);
                    Framerack.SetActive(false);
                    FramePlane.SetActive(true);
                    FrameSupport1.SetActive(false);
                    FrameSupport2.SetActive(false);
                }
                else if (rayhit.transform.name.Equals("Support1"))
                {
                    WhatObject = GameObject.FindGameObjectWithTag(rayhit.transform.name);
                    FrameLaser.SetActive(false);
                    Framerack.SetActive(false);
                    FramePlane.SetActive(false);
                    FrameSupport1.SetActive(true);
                    FrameSupport2.SetActive(false);
                }
                else if (rayhit.transform.name.Equals("Support2"))
                {
                    WhatObject = GameObject.FindGameObjectWithTag(rayhit.transform.name);
                    FrameLaser.SetActive(false);
                    Framerack.SetActive(false);
                    FramePlane.SetActive(false);
                    FrameSupport1.SetActive(false);
                    FrameSupport2.SetActive(true);
                }
            }
        }
        if (WhatObject != null && ResultTable.TableOpen == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) || MoveControls.RightClick == false)
            {
                WhatObject.transform.position += new Vector3(0.01f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || MoveControls.LeftClik == false)
            {
                WhatObject.transform.position -= new Vector3(0.01f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow) || MoveControls.TopClick == false)
            {
                WhatObject.transform.position += new Vector3(0, 0, 0.01f);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || MoveControls.BottomClick == false)
            {
                WhatObject.transform.position -= new Vector3(0, 0, 0.01f);
            }
            else if (Input.GetKey(KeyCode.Z) || MoveControls.Rotate1Click == false)
            {
                WhatObject.transform.Rotate(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.X) || MoveControls.Rotate2Click == false)
            {
                WhatObject.transform.Rotate(Vector3.down);
            }
            else if (Input.GetKey(KeyCode.C) || MoveControls.CenterClick == false)
            {
                WhatObject.transform.position += new Vector3(0, 0.04f, 0);
                WhatObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
