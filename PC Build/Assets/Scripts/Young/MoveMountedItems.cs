using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveMountedItems : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool RightClick = true;
    private bool LeftClik = true;
    private double RackMinus;
    private double RackPlus;

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

    void Start()
    {
        RackMinus = Rack.transform.position.x - 1.7;
        RackPlus = Rack.transform.position.x + 1.7;
    }

    void Update()
    {
        if(RightClick == false && Rack.transform.position.x + 0.01 <= RackPlus)
        {
            Rack.transform.position += new Vector3(0.01f, 0, 0);
        }
        else if(LeftClik == false && Rack.transform.position.x - 0.01 >= RackMinus)
        {
            Rack.transform.position -= new Vector3(0.01f, 0, 0);
        }
    }
}
