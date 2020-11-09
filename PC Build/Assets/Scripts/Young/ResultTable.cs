using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;


public class ResultTable : MonoBehaviour {

    public GameObject resultTable;

    public List<InputField> Table1;
    public List<InputField> Table2;
    public List<InputField> Table3;
    public GameObject mailPanel;
    public List<InputField> Mails;


    public static bool TableOpen = false;
    private bool PDFGenerated = false;

    void Start () {
    }
	
	void Update () {

	}

    public void AnimTable()
    {

    }

    public void GuardaPDF()
    {
    }

    public void MailPanel()
    {
    }

    public void CloseMailPanel()
    {
    }

    public void EnviaPDF()
    {
        
    }

    private void GeneraPDF(string path)
    {
      
    }
}
