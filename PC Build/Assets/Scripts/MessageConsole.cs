using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageConsole : MonoBehaviour {

    public GameObject messageConsole;
    public TextMeshProUGUI MessageTextField;
    public static string Message;
    private string PreviousMessage;

    List<string> list = new List<string>();

	void Update () {
        if (!string.IsNullOrEmpty(Message))
        {
            if (string.IsNullOrEmpty(PreviousMessage))
            {
                PreviousMessage = Message;
                list.Add(Message);
                Message = "";
            }
            else
            {
                if (!Message.Equals(PreviousMessage) || !messageConsole.GetComponent<Animation>().IsPlaying("NewMessage"))
                {
                    list.Add(Message);
                    Message = "";
                }
            }
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
