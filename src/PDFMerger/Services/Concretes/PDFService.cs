using Microsoft.Office.Interop.Excel;
using PDFMerger.Services.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PDFMerger.Services.Concretes
{
    public class PDFService : IPDFService
    {
        public async Task Merge(Application excelApp, string excelFilePath)
        {
            excelApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Sheets workSheets = workbook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Worksheet)workSheets.get_Item(1);
            //Microsoft.Office.Interop.Excel.Range bColumn = sheet.get_Range("A", null);
            Microsoft.Office.Interop.Excel.Range firstColumn = (Microsoft.Office.Interop.Excel.Range)workSheet.UsedRange.Columns[1];
            System.Array myvalues = (System.Array)firstColumn.Cells.Value;
            string[] pdfFilePaths = myvalues.OfType<object>().Select(o => o.ToString()).ToArray();

            List<PdfDocument> pdfDocuments = new();

            foreach (var pdfFilePath in pdfFilePaths)
            {
                pdfDocuments.Add(PdfReader.Open(pdfFilePath, PdfDocumentOpenMode.Import));
            }

            var counter = 1;

            var outPdf = new PdfDocument();

            foreach (var pdfDocument in pdfDocuments)
            {
                CopyPages(pdfDocument, outPdf);

                if (pdfDocuments.IndexOf(pdfDocument) % 50 == 0 || pdfDocuments.IndexOf(pdfDocument) == pdfDocuments.Count - 1)
                {
                    counter++;
                    outPdf.Save($"MergedPDF-{counter}.pdf");

                    outPdf = null;
                    outPdf = new PdfDocument();
                }
            }
        }

        private void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
    }
}