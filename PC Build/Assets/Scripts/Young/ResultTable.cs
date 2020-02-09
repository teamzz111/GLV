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
using System.Net.Security;

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
        CloseMailPanel();
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            AnimTable();
        }
	}

    public void AnimTable()
    {
        if (TableOpen == false && !resultTable.GetComponent<Animation>().IsPlaying("Hide"))
        {
            resultTable.GetComponent<Animation>().Play("Show");
            TableOpen = true;
        }
        else if (!resultTable.GetComponent<Animation>().IsPlaying("Show"))
        {
            resultTable.GetComponent<Animation>().Play("Hide");
            TableOpen = false;
        }
    }

    public void MailPanel()
    {
        mailPanel.SetActive(true);
    }

    public void CloseMailPanel()
    {
        mailPanel.SetActive(false);
    }

    public void EnviaPDF()
    {
        CloseMailPanel();
        string FilePDF = Directory.GetCurrentDirectory() + @"\file.pdf";
        PDFGenerated = false;
        GeneraPDF(FilePDF);
        if (PDFGenerated == true)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("guiaslaboratoriosvirtuales@gmail.com");
                foreach (InputField I in Mails)
                {
                    if (!string.IsNullOrEmpty(I.text))
                    {
                        mail.To.Add(I.text);
                    }
                }
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("guiaslaboratoriosvirtuales@gmail.com", "GLV0315GLV") as ICredentialsByHost;
                smtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
                mail.Attachments.Add(new Attachment(Path.GetFileName(FilePDF)));
                smtpServer.Send(mail);
                AnimTable();
                MessageConsole.Message = "El mail se ha enviado satisfactoriamente";
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
                CloseMailPanel();
                AnimTable();
                MessageConsole.Message = "Ocurrió un error al enviar el archivo, intente de nuevo";
            }
        }
    }

    private void GeneraPDF(string path)
    {
        Document doc = new Document(PageSize.LETTER);
        FileStream FS = new FileStream(path, FileMode.Create);
        PdfWriter writer = PdfWriter.GetInstance(doc, FS);
        PdfPTable Table = new PdfPTable(2);
        try
        {
            doc.AddTitle("Tabla de resultados de laboratorio");
            doc.AddCreator("GLV");
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 20f, iTextSharp.text.Font.BOLD);
            Paragraph Parrafo = new Paragraph("Resultados del Experimento de Young", _standardFont);
            Parrafo.Alignment = Element.ALIGN_CENTER;
            doc.Add(Parrafo);
            doc.Add(Chunk.NEWLINE);

            _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12f, iTextSharp.text.Font.NORMAL);
            
            Table.WidthPercentage = 80;

            PdfPCell cell = new PdfPCell(new Phrase("Longitud de onda: " + Table1[0].text + "\nN: " + Table1[1].text));
            cell.Colspan = 2;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Padding = 10;
            Table.AddCell(cell);

            _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 15f, iTextSharp.text.Font.BOLD);
            cell = new PdfPCell(new Phrase("L (m)", _standardFont));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5;
            Table.AddCell(cell);

            cell = new PdfPCell(new Phrase("y (m)", _standardFont));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5;
            Table.AddCell(cell);

            _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10f, iTextSharp.text.Font.NORMAL);

            string Text = "";
            int Index = 0;
            foreach (InputField I in Table1)
            {
                if(Index >= 2)
                {
                    if (string.IsNullOrEmpty(I.text))
                    {
                        Text = " ";
                    }
                    else
                    {
                        Text = I.text;
                    }
                    cell = new PdfPCell(new Phrase(Text, _standardFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Padding = 4;
                    Table.AddCell(cell);
                }
                Index++;
            }

            cell = new PdfPCell(new Phrase("Longitud de onda: " + Table2[0].text + "\nN: " + Table2[1].text));
            cell.Colspan = 2;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Padding = 10;
            Table.AddCell(cell);

            _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 15f, iTextSharp.text.Font.BOLD);
            cell = new PdfPCell(new Phrase("L (m)", _standardFont));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5;
            Table.AddCell(cell);

            cell = new PdfPCell(new Phrase("y (m)", _standardFont));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5;
            Table.AddCell(cell);

            _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10f, iTextSharp.text.Font.NORMAL);

            Text = "";
            Index = 0;
            foreach (InputField I in Table2)
            {
                if (Index >= 2)
                {
                    if (string.IsNullOrEmpty(I.text))
                    {
                        Text = " ";
                    }
                    else
                    {
                        Text = I.text;
                    }
                    cell = new PdfPCell(new Phrase(Text, _standardFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Padding = 4;
                    Table.AddCell(cell);
                }
                Index++;
            }

            cell = new PdfPCell(new Phrase("Longitud de onda: " + Table3[0].text + "\nN: " + Table3[1].text));
            cell.Colspan = 2;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Padding = 10;
            Table.AddCell(cell);

            _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 15f, iTextSharp.text.Font.BOLD);
            cell = new PdfPCell(new Phrase("L (m)", _standardFont));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5;
            Table.AddCell(cell);

            cell = new PdfPCell(new Phrase("y (m)", _standardFont));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5;
            Table.AddCell(cell);

            _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10f, iTextSharp.text.Font.NORMAL);

            Text = "";
            Index = 0;
            foreach (InputField I in Table3)
            {
                if (Index >= 2)
                {
                    if (string.IsNullOrEmpty(I.text))
                    {
                        Text = " ";
                    }
                    else
                    {
                        Text = I.text;
                    }
                    cell = new PdfPCell(new Phrase(Text, _standardFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Padding = 4;
                    Table.AddCell(cell);
                }
                Index++;
            }
            doc.Add(Table);
            PDFGenerated = true;
        }
        catch
        {
            AnimTable();
            MessageConsole.Message = "Ocurrió un error al guardar el archivo, intente de nuevo";
        }
        finally
        {
            doc.Close();
            writer.Close();
            FS.Close();
            FS.Dispose();
        }
    }
}
