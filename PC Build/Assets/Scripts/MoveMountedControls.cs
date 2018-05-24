using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveMountedControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool RightClick = true;
    private bool LeftClik = true;

    public GameObject Rack;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.gameObject.name.Equals("Right")) { RightClick = false; }
        else if (this.gameObject.name.Equals("Left")) { LeftClik = false; }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RightClick = true;
        LeftClik = true;
    }

    void Update()
    {
        if(RightClick == false)
        {
            Rack.transform.position += new Vector3(0.07f, 0, 0);
        }
        else if(LeftClik == false)
        {
            Rack.transform.position -= new Vector3(0.07f, 0, 0);
        }
    }
}
