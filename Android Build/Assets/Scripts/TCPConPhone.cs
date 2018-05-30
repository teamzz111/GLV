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
using UnityEngine.SceneManagement;

public class TCPConPhone : MonoBehaviour
{
    public TextMeshPro MessageBox;
    public TextMeshPro IP;
    public AudioSource ErrorSound;

    private TcpListener tcpListener;
    private Thread tcpListenerThread;
    private TcpClient connectedTcpClient;
    
    private static readonly Queue<Action> _executionQueue = new Queue<Action>();

    public static string SceneName = "";

    void Start()
    {
        StartConfig();
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
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
        MessageBox.text = "Esperando conexión...";
    }
    
    private void ListenRequests()
    {
        try
        {
            string LocalIP = GetLocalIPAddress();
            if (!LocalIP.Equals("error") && !LocalIP.Equals("127.0.0.1"))
            {
                Enqueue(() => IP.text += LocalIP);
                tcpListener = new TcpListener(IPAddress.Parse(LocalIP), 4444);
                tcpListener.Start();
                Byte[] bytes = new Byte[1024];
                while (true)
                {
                    if (!string.IsNullOrEmpty(SceneName) && !SceneName.Equals("0"))
                    {
                        SceneName = "";
                        Enqueue(() => {
                            Destroy(this.gameObject);
                            SceneManager.LoadScene(0);
                        });
                        break;
                    }
                    else
                    {
                        using (connectedTcpClient = tcpListener.AcceptTcpClient())
                        {
                            Enqueue(() => MessageBox.text = "Iniciando sesión...");
                            using (NetworkStream stream = connectedTcpClient.GetStream())
                            {
                                int length;
                                var incommingData = new byte[0];
                                while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                                {
                                    incommingData = new byte[length];
                                    Array.Copy(bytes, 0, incommingData, 0, length);
                                    GetCommands(Encoding.ASCII.GetString(incommingData));
                                }
                                stream.Close();
                            }
                            connectedTcpClient.Close();
                        }
                    }

                }
            }
            else
            {
                Enqueue(() => {
                    MessageBox.fontSize = 5;
                    MessageBox.text = "Error: ¿Estás conectad@ a internet?";
                });
            }
        }
        catch (Exception ex)
        {
            Enqueue(() => {
                MessageBox.fontSize = 5;
                MessageBox.text = "Error: ¿Estás conectad@ a internet?";
            });
        }
    }

    public void GetCommands(string command)
    {
        try
        {
            foreach(string s in command.Split('&'))
            {
                if (!string.IsNullOrEmpty(s))
                {
                    if (s.Split('|')[0].Equals("Map"))
                    {
                        SceneName = s.Split('|')[1];
                        Enqueue(() => SceneManager.LoadScene(Convert.ToInt32(s.Split('|')[1])));
                    }
                    else if (s.Split('|')[0].Equals("P"))
                    {
                        GetItemPosition.Position.Add(s.Split('|')[1]);
                    }
                    else if (s.Split('|')[0].Equals("R"))
                    {
                        GetItemPosition.Rotation.Add(s.Split('|')[1]);
                    }
                    else if (s.Split('|')[0].Equals("S"))
                    {
                        GetItemPosition.Scale.Add(s.Split('|')[1]);
                    }
                    else if (s.Split('|')[0].Equals("Col"))
                    {
                        SupportCollition.NewCollition = s.Split('|')[1];
                    }
                    else if (s.Split('|')[0].Equals("Pre"))
                    {
                        Young.GetValues = s.Split('|')[1];
                    }
                    else if (s.Split('|')[0].Equals("Montaje"))
                    {
                        Montaje.MontajeCompleto = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
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

    private static TCPConPhone _instance = null;

    public static bool Exists()
    {
        return _instance != null;
    }

    public static TCPConPhone Instance()
    {
        if (!Exists())
        {
            throw new Exception("UnityMainThreadDispatcher could not find the UnityMainThreadDispatcher object. Please ensure you have added the MainThreadExecutor Prefab to your scene.");
        }
        return _instance;
    }

    void OnDestroy()
    {
        _instance = null;
    }
}