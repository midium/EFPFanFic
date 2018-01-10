using Midium.Helpers.Threading;
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

        public bool SaveHtmlToPDF(string htmlUri, string fileName, string fanFicName)
        {
            try
            {
                _threadManager.StartNewThread(() => ConvertHtmlToPDF(htmlUri, fileName), fanFicName);
                return true;
            } catch (Exception e)
            {
                return false;
            }            
        }

        private void ConvertHtmlToPDF(string htmlUri, string fileName)
        {
            try
            {
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.GeneratePdfFromFile(htmlUri, null, fileName);
                MessageBox.Show(string.Format("{0} saved correctly.", fileName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception e)
            {
                MessageBox.Show("Unable to convert the given HTML to PDF.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
