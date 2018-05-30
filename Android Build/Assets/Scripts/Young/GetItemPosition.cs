using System;
using System.Collections.Generic;
using UnityEngine;

public class GetItemPosition : MonoBehaviour {

    public GameObject Laser;
    public GameObject Plane;
    public GameObject Rack;
    public GameObject Support1;
    public GameObject Support2;

    public GameObject MountedSupport;
    public GameObject Laser1A;
    public GameObject Laser1D;
    public GameObject Laser2A;
    public GameObject Laser2D;

    public static List<string> Position = new List<string>();
    public static List<string> Rotation = new List<string>();
    public static List<string> Scale = new List<string>();

    private string getPosition;
    private Vector3 Pos;
    private string getRotation;
    private Vector3 Rot;
    private string getScale;
    private Vector3 Sca;
    private char WhatItemPos;
    private string ItemInfo;

	void Update () {
        try
        {
            if (Montaje.MontajeCompleto == false)
            {
                if (Position.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ItemInfo = Position[0].Split(';')[i];
                        getPosition = ItemInfo.Remove(ItemInfo.Length - 1).Split('(')[1];
                        Pos = new Vector3(float.Parse(getPosition.Split(',')[0]), float.Parse(getPosition.Split(',')[1]), float.Parse(getPosition.Split(',')[2]));
                        WhatItemPos = ItemInfo[0];
                        if (WhatItemPos == '0')
                        {
                            Laser.transform.position = Pos;
                        }
                        else if (WhatItemPos == '1')
                        {
                            Plane.transform.position = Pos;
                        }
                        else if (WhatItemPos == '2')
                        {
                            Rack.transform.position = Pos;
                        }
                        else if (WhatItemPos == '3')
                        {
                            Support1.transform.position = Pos;
                        }
                        else if (WhatItemPos == '4')
                        {
                            Support2.transform.position = Pos;
                        }
                    }
                    Position.RemoveAt(0);
                }
                if (Rotation.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ItemInfo = Rotation[0].Split(';')[i];
                        getRotation = ItemInfo.Remove(ItemInfo.Length - 1).Split('(')[1];
                        Rot = new Vector3(float.Parse(getRotation.Split(',')[0]), float.Parse(getRotation.Split(',')[1]), float.Parse(getRotation.Split(',')[2]));
                        WhatItemPos = ItemInfo[0];
                        if (WhatItemPos == '0')
                        {
                            Laser.transform.eulerAngles = Rot;
                        }
                        else if (WhatItemPos == '1')
                        {
                            Plane.transform.eulerAngles = Rot;
                        }
                        else if (WhatItemPos == '2')
                        {
                            Rack.transform.eulerAngles = Rot;
                        }
                        else if (WhatItemPos == '3')
                        {
                            Support1.transform.eulerAngles = Rot;
                        }
                        else if (WhatItemPos == '4')
                        {
                            Support2.transform.eulerAngles = Rot;
                        }
                    }
                    Rotation.RemoveAt(0);
                }
            }
            else
            {
                if (Position.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ItemInfo = Position[0].Split(';')[i];
                        getPosition = ItemInfo.Remove(ItemInfo.Length - 1).Split('(')[1];
                        Pos = new Vector3(float.Parse(getPosition.Split(',')[0]), float.Parse(getPosition.Split(',')[1]), float.Parse(getPosition.Split(',')[2]));
                        WhatItemPos = ItemInfo[0];
                        if (WhatItemPos == '0')
                        {
                            MountedSupport.transform.position = Pos;
                        }
                        else if (WhatItemPos == '1')
                        {
                            Laser1A.transform.position = Pos;
                        }
                        else if (WhatItemPos == '2')
                        {
                            Laser1D.transform.position = Pos;
                        }
                        else if (WhatItemPos == '3')
                        {
                            Laser2A.transform.position = Pos;
                        }
                        else if (WhatItemPos == '4')
                        {
                            Laser2D.transform.position = Pos;
                        }
                    }
                    Position.RemoveAt(0);
                }
                if (Scale.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ItemInfo = Scale[0].Split(';')[i];
                        getScale = ItemInfo.Remove(ItemInfo.Length - 1).Split('(')[1];
                        Sca = new Vector3(0.02f, float.Parse(getScale.Split(',')[1]), 0.02f);
                        WhatItemPos = ItemInfo[0];
                        if (WhatItemPos == '0')
                        {
                            Sca = new Vector3(float.Parse(getScale.Split(',')[0]), float.Parse(getScale.Split(',')[1]), float.Parse(getScale.Split(',')[2]));
                            MountedSupport.transform.localScale = Sca;
                        }
                        else if (WhatItemPos == '1')
                        {
                            Laser1A.transform.localScale = Sca;
                        }
                        else if (WhatItemPos == '2')
                        {
                            Laser1D.transform.localScale = Sca;
                        }
                        else if (WhatItemPos == '3')
                        {
                            Laser2A.transform.localScale = Sca;
                        }
                        else if (WhatItemPos == '4')
                        {
                            Laser2D.transform.localScale = Sca;
                        }
                    }
                    Scale.RemoveAt(0);
                }
                if (Rotation.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ItemInfo = Rotation[0].Split(';')[i];
                        getRotation = ItemInfo.Remove(ItemInfo.Length - 1).Split('(')[1];
                        Rot = new Vector3(float.Parse(getRotation.Split(',')[0]), float.Parse(getRotation.Split(',')[1]), float.Parse(getRotation.Split(',')[2]));
                        WhatItemPos = ItemInfo[0];
                        if (WhatItemPos == '0')
                        {
                            MountedSupport.transform.eulerAngles = Rot;
                        }
                        else if (WhatItemPos == '1')
                        {
                            Laser1A.transform.eulerAngles = Rot;
                        }
                        else if (WhatItemPos == '2')
                        {
                            Laser1D.transform.eulerAngles = Rot;
                        }
                        else if (WhatItemPos == '3')
                        {
                            Laser2A.transform.eulerAngles = Rot;
                        }
                        else if (WhatItemPos == '4')
                        {
                            Laser2D.transform.eulerAngles = Rot;
                        }
                    }
                    Rotation.RemoveAt(0);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
}
