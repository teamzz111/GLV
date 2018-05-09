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
    public static string OnPlayCommands = "";
    private bool Connecting = false;

    void Start () {
        Connect.onClick.AddListener(ConnectServer);
    }

    void Update()
    {
        if (!string.IsNullOrEmpty(OnPlayCommands))
        {
            if (OnPlayCommands.Split('|')[0].Equals("Desconnect"))
            {
                client.Close();
                OnPlayCommands = "";
            }
            else if (OnPlayCommands.Split('|')[0].Equals("Message"))
            {
                sendMessage("Map|" + OnPlayCommands.Split('|')[1]);
                OnPlayCommands = "";
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
