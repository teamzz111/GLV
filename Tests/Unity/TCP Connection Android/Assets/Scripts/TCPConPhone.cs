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

public class TCPConPhone : MonoBehaviour
{

    public Button StartServer;
    public Text Box;
    public Text IP;

    private TcpListener tcpListener;
    private Thread tcpListenerThread;
    private TcpClient connectedTcpClient;
    
    private static readonly Queue<Action> _executionQueue = new Queue<Action>();

    void Start()
    {
        StartServer.onClick.AddListener(StartConfig);
    }

    public void Update()
    {
        lock (_executionQueue)
        {
            while (_executionQueue.Count > 0)
            {
                _executionQueue.Dequeue().Invoke();
            }
        }
    }

    public void StartConfig()
    {
        tcpListenerThread = new Thread(new ThreadStart(ListenRequests));
        tcpListenerThread.IsBackground = true;
        tcpListenerThread.Start();
        Box.text = "Server started\n";
    }

    private void ListenRequests()
    {
        try
        {
            string LocalIP = GetLocalIPAddress();
            if (!LocalIP.Equals("error"))
            {
                Enqueue(() => IP.text += LocalIP);
                tcpListener = new TcpListener(IPAddress.Parse(LocalIP), 4444);
                tcpListener.Start();
                Byte[] bytes = new Byte[1024];
                while (true)
                {
                    using (connectedTcpClient = tcpListener.AcceptTcpClient())
                    {
                        using (NetworkStream stream = connectedTcpClient.GetStream())
                        {
                            int length;				
                            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                            {
                                var incommingData = new byte[length];
                                Array.Copy(bytes, 0, incommingData, 0, length);						
                                string clientMessage = Encoding.ASCII.GetString(incommingData);
                                Enqueue(() => Box.text = clientMessage);
                            }
                        }
                    }
                }
            }
            else
            {
                Enqueue(() => Box.text = "The server couldn't get the IP\n");
            }
        }
        catch
        {
            Enqueue(() => Box.text = "An error ocurred while configuring the server\n");
        }
    }
    
    
    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "error";
    }

    public void Enqueue(IEnumerator action)
    {
        lock (_executionQueue)
        {
            _executionQueue.Enqueue(() => {
                StartCoroutine(action);
            });
        }
    }

    public void Enqueue(Action action)
    {
        Enqueue(ActionWrapper(action));
    }
    IEnumerator ActionWrapper(Action a)
    {
        a();
        yield return null;
    }


}