﻿using Midium.Helpers.Threading;
using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using TheArtOfDev.HtmlRenderer.Core;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Midium.Helpers.PDF
{
    public class PDFManager
    {
        private readonly ThreadsManager _threadManager;

        public ThreadsManager ThreadManager { get => _threadManager; }

        public PDFManager()
        {
            _threadManager = new ThreadsManager();
        }

        public bool SaveHtmlToPDF(string htmlSource, string css, string fileName, string fanFicName)
        {
            try
            {
                _threadManager.StartNewThread(() => ConvertHtmlToPDF(htmlSource, css, fileName), fanFicName);
                return true;
            } catch (Exception e)
            {
                return false;
            }            
        }

        private string GetCssContent(string cssUri)
        {
            var webRequest = WebRequest.Create(cssUri);

            using (var response = webRequest.GetResponse())
            using(var content = response.GetResponseStream())
            using(var reader = new StreamReader(content)){
                return reader.ReadToEnd();
            }

        }

        private void ConvertHtmlToPDF(string htmlSource, string css, string fileName)
        {
            CssData cssData = PdfGenerator.ParseStyleSheet(GetCssContent(css));
            PdfDocument pdf = PdfGenerator.GeneratePdf(htmlSource, PageSize.A4, 20, cssData);

            if (pdf != null && pdf.PageCount>0 && fileName != string.Empty)
            {
                pdf.Save(fileName);
                MessageBox.Show(string.Format("{0} saved correctly.", fileName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Unable to convert the given HTML to PDF.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
