using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    

    public static bool RightClick = true;
    public static bool LeftClik = true;
    public static bool TopClick = true;
    public static bool BottomClick = true;
    public static bool Rotate1Click = true;
    public static bool Rotate2Click = true;
    public static bool CenterClick = true;
    public static bool AnyControl = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        AnyControl = false;

        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.name.Equals("Right")) { BottomClick = false; }
            else if (this.gameObject.name.Equals("Left")) { TopClick = false; }
            else if (this.gameObject.name.Equals("Top")) { RightClick = false; }
            else if (this.gameObject.name.Equals("Bottom")) { LeftClik = false; }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.name.Equals("Right")) { TopClick = false; }
            else if (this.gameObject.name.Equals("Left")) { BottomClick = false; }
            else if (this.gameObject.name.Equals("Top")) { LeftClik = false; }
            else if (this.gameObject.name.Equals("Bottom")) { RightClick = false; }
        }
        else
        {
            if (this.gameObject.name.Equals("Right")) { RightClick = false; }
            else if (this.gameObject.name.Equals("Left")) { LeftClik = false; }
            else if (this.gameObject.name.Equals("Top")) { TopClick = false; }
            else if (this.gameObject.name.Equals("Bottom")) { BottomClick = false; }
        }

        if (this.gameObject.name.Equals("Rotate1")) { Rotate1Click = false; }
        else if (this.gameObject.name.Equals("Rotate2")) { Rotate2Click = false; }
        else if (this.gameObject.name.Equals("Center")) { CenterClick = false; }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AnyControl = true;
        RightClick = true;
        LeftClik = true;
        TopClick = true;
        BottomClick = true;
        Rotate1Click = true;
        Rotate2Click = true;
        CenterClick = true;
    }
}
