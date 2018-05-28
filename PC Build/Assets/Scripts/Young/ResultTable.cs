using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
#if UNITY_EDITOR || UNITY_STANDALONE
using System.Windows.Forms;
#endif

public class ResultTable : MonoBehaviour {

    public GameObject resultTable;

    public List<InputField> Table1;
    public List<InputField> Table2;
    public List<InputField> Table3;
    public GameObject mailPanel;
    public List<InputField> Mails;


    private bool TableOpen = false;
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

    public void GuardaPDF()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE
        string path = "";
        SaveFileDialog dlg = new SaveFileDialog();
        dlg.DefaultExt = ".pdf";
        dlg.InitialDirectory = UnityEngine.Application.dataPath;
        dlg.Filter = "Pdf documents (.pdf)|*.pdf";
        dlg.FileName = "TablaResultados";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            path = dlg.FileName;
            try
            {
                GeneraPDF(path);
                MessageConsole.Message = "El archivo se ha guardado correctamente";
            }
            catch
            {
                AnimTable();
                MessageConsole.Message = "Ocurrió un error al guardar el archivo, intente de nuevo";
            }
            finally
            {
                path = "";
            }
            AnimTable();
        }
        else
        {
            path = "";
            AnimTable();
            MessageConsole.Message = "No se ha guardado el archivo";
        }
        #endif
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
        PDFGenerated = false;
        string FilePDF = Directory.GetCurrentDirectory() + @"\file.pdf";
        #if UNITY_EDITOR || UNITY_STANDALONE
        try
        {
            GeneraPDF(FilePDF);
        }
        catch
        {
            AnimTable();
            MessageConsole.Message = "Ocurrió un error al guardar el archivo, intente de nuevo";
        }
        #endif
        if(PDFGenerated == true)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("guiaslaboratoriosvirtuales@gmail.com", "GLV0315GLV"); ;
            client.EnableSsl = true;
            client.Timeout = 10000;

            MailMessage Mensaje = new MailMessage();
            Mensaje.Subject = "Tabla de resultados";
            Mensaje.From = new MailAddress("guiaslaboratoriosvirtuales@gmail.com");
            Mensaje.Body = "GLV te ha generado una tabla de resultados:";
            foreach (InputField I in Mails)
            {
                if (!string.IsNullOrEmpty(I.text))
                {
                    Mensaje.To.Add(I.text);
                }
            }
            try
            {
                Mensaje.Attachments.Add(new Attachment(Path.GetFileName(FilePDF)));
                client.Send(Mensaje);
                AnimTable();
                MessageConsole.Message = "El mail se ha enviado satisfactoriamente";
                Mensaje.Dispose();
                File.Delete(FilePDF);
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
        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
        doc.AddTitle("Tabla de resultados de laboratorio");
        doc.AddCreator("GLV");
        doc.Open();

        iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 20f, iTextSharp.text.Font.BOLD);
        Paragraph Parrafo = new Paragraph("Resultados del Experimento de Young", _standardFont);
        Parrafo.Alignment = Element.ALIGN_CENTER;
        doc.Add(Parrafo);
        doc.Add(Chunk.NEWLINE);

        _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12f, iTextSharp.text.Font.NORMAL);

        PdfPTable Table = new PdfPTable(2);
        Table.WidthPercentage = 80;

        PdfPCell cell = new PdfPCell(new Phrase("Longitud de onda: " + "\nN: "));
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

        foreach(InputField I in Table1)
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

        cell = new PdfPCell(new Phrase("Longitud de onda: " + "\nN: "));
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

        foreach (InputField I in Table2)
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

        cell = new PdfPCell(new Phrase("Longitud de onda: " + "\nN: "));
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

        foreach (InputField I in Table3)
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

        doc.Add(Table);
        doc.Close();
        writer.Close();
        PDFGenerated = true;
    }
}
