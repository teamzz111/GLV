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

public class TCPConPC : MonoBehaviour {

    public InputField IP;
    public InputField Message;
    public Button Connect;
    public Button Send;

    string Ip;
    string message;

    TcpClient client;

    // Use this for initialization
    void Start () {
        Connect.onClick.AddListener(ConnectServer);
        Send.onClick.AddListener(SendMessage);
    }

    void ConnectServer()
    {
        Ip = IP.text;
        try
        {
            // Create a TcpClient.
            Message.text = "Connecting...";
            client = new TcpClient(Ip, 4444);
            Message.text = "Connected";
        }
        catch
        {
            Message.text = "The server seems to be down";
        }
    }

    void SendMessage()
    {
        try
        {
            message = Message.text;
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();
            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);
            Message.text = "Message send";
        }
        catch
        {
            Message.text = "An error ocurred while sending a message";
        }
    }
}
