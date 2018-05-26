using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageConsole : MonoBehaviour {

    public GameObject messageConsole;
    public TextMeshProUGUI MessageTextField;
    public static string Message;

    List<string> list = new List<string>();

	void Update () {
        if (!string.IsNullOrEmpty(Message))
        {
            list.Add(Message);
            Message = "";
        }
        if(list.Count != 0)
        {
            if (!messageConsole.GetComponent<Animation>().IsPlaying("NewMessage"))
            {
                MessageTextField.text = list[0];
                messageConsole.GetComponent<Animation>().Play("NewMessage");
                list.RemoveAt(0);
            }
        }
	}
}
