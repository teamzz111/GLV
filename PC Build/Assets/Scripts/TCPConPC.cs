using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;

public class TCPConPC : MonoBehaviour {

    public AudioSource ErrorSound;
    public InputField IP;
    public TextMeshProUGUI MessageBox;
    public Button Connect;

    string Ip;
    string message;

    TcpClient client;

    private static bool Created = false;
    public static List<string> OnPlayCommands;
    private bool Connecting = false;

    void Start () {
        Connect.onClick.AddListener(ConnectServer);
        OnPlayCommands = new List<string>();
    }

    void Update()
    {
        if (OnPlayCommands.Count > 0)
        {
            if (OnPlayCommands[0].Split('|')[0].Equals("Desconnect"))
            {
                client.Close();
                OnPlayCommands.RemoveAt(0);
            }
            else if (OnPlayCommands[0].Split('|')[0].Equals("Map"))
            {
                sendMessage("Map|" + OnPlayCommands[0].Split('|')[1]);
                OnPlayCommands.RemoveAt(0);
            }
            else if (OnPlayCommands[0].Split('|')[0].Equals("QueLab"))
            {
                sendMessage("QueLab|" + OnPlayCommands[0].Split('|')[1]);
                OnPlayCommands.RemoveAt(0);
            }
            else if (OnPlayCommands[0].Split('|')[0].Equals("Position"))
            {
                sendMessage("P|" + OnPlayCommands[0].Split('|')[1]);
                OnPlayCommands.RemoveAt(0);
            }
            else if (OnPlayCommands[0].Split('|')[0].Equals("Rotation"))
            {
                sendMessage("R|" + OnPlayCommands[0].Split('|')[1]);
                OnPlayCommands.RemoveAt(0);
            }
            else if (OnPlayCommands[0].Split('|')[0].Equals("Scale"))
            {
                sendMessage("S|" + OnPlayCommands[0].Split('|')[1]);
                OnPlayCommands.RemoveAt(0);
            }
            else if (OnPlayCommands[0].Split('|')[0].Equals("Collition"))
            {
                sendMessage("Col|" + OnPlayCommands[0].Split('|')[1]);
                OnPlayCommands.RemoveAt(0);
            }
            else if (OnPlayCommands[0].Split('|')[0].Equals("Montaje"))
            {
                sendMessage("Montaje|" + OnPlayCommands[0].Split('|')[1]);
                OnPlayCommands.RemoveAt(0);
            }
            else if (OnPlayCommands[0].Split('|')[0].Equals("Prediction"))
            {
                sendMessage("Pre|" + OnPlayCommands[0].Split('|')[1]);
                OnPlayCommands.RemoveAt(0);
            }
            else
            {
                OnPlayCommands.RemoveAt(0);
            }
        }
    }

    void ConnectServer()
    {
        if(Connecting == false)
        {
            Connecting = true;
            Ip = IP.text;
            if (string.IsNullOrEmpty(Ip))
            {
                MessageBox.text = "La direccón IP no es correcta";
            }
            try
            {
                MessageBox.text = "Conectando...";
                client = new TcpClient(Ip, 4444);
                Connecting = false;
                MessageBox.text = "Iniciando sesión...";
            }
            catch
            {
                ErrorSound.Play();
                Connecting = false;
                MessageBox.text = "No se ha podido conectar, revise la conexión a internet y la dirección IP";
            }
        }
    }

    void sendMessage(string Message)
    {
        Message = Message + "&";
        try
        {
            Byte[] data = Encoding.ASCII.GetBytes(Message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
        }
        catch
        {
            Debug.Log("An error ocurred while sending a message");
        }
    }

    void Awake()
    {
        if (!Created)
        {
            DontDestroyOnLoad(this.gameObject);
            Created = true;
        }
    }
}
