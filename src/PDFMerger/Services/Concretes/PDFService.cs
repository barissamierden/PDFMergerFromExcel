using Microsoft.Office.Interop.Excel;
using PDFMerger.Services.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Diagnostics;

namespace PDFMerger.Services.Concretes
{
    public class PDFService : IPDFService
    {
        public async Task Merge(Application excelApp, string excelFilePath)
        {
            var sw = new Stopwatch();

            sw.Start();

            excelApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Sheets workSheets = workbook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Worksheet)workSheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range pdfFilePathsColumn = (Microsoft.Office.Interop.Excel.Range)workSheet.UsedRange.Columns[1];
            Microsoft.Office.Interop.Excel.Range pdfFileNamesColumn = (Microsoft.Office.Interop.Excel.Range)workSheet.UsedRange.Columns[2];
            Microsoft.Office.Interop.Excel.Range savePathsColumn = (Microsoft.Office.Interop.Excel.Range)workSheet.UsedRange.Columns[3];
            System.Array pdfFilePathValues = (System.Array)pdfFilePathsColumn.Cells.Value;
            string?[] pdfFilePathsArr = pdfFilePathValues.OfType<object>().Select(o => o.ToString()).ToArray();
            System.Array pdfFileNameValues = (System.Array)pdfFileNamesColumn.Cells.Value;
            string?[] pdfFileNamesArr = pdfFileNameValues.OfType<object>().Select(o => o.ToString()).ToArray();
            System.Array savePathValues = (System.Array)savePathsColumn.Cells.Value;
            string?[] savePathsArr = savePathValues.OfType<object>().Select(o => o.ToString()).ToArray();

            List<PdfDocument> pdfDocuments = new();

            foreach (var pdfFilePath in pdfFilePathsArr)
            {
                pdfDocuments.Add(PdfReader.Open(pdfFilePath, PdfDocumentOpenMode.Import));
            }

            var pdfCounter = 1;
            var counter = 1;

            var outPdf = new PdfDocument();

            foreach (var pdfDocument in pdfDocuments)
            {
                CopyPages(pdfDocument, outPdf);

                if (pdfCounter % 51 == 0 || pdfDocuments.IndexOf(pdfDocument) == pdfDocuments.Count - 1)
                //if (pdfDocuments.IndexOf(pdfDocument) != 0 && (pdfDocuments.IndexOf(pdfDocument) % 50 == 0 || pdfDocuments.IndexOf(pdfDocument) == pdfDocuments.Count - 1))
                {
                    outPdf.Save($"{savePathsArr[counter - 1]}{pdfFileNamesArr[counter - 1]}.pdf");
                    counter++;
                    outPdf = null;
                    outPdf = new PdfDocument();
                    pdfCounter = 0;
                }

                pdfCounter++;
            }

            excelApp.Quit();
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            await Console.Out.WriteLineAsync("Total Elapsed Time: " + (sw.ElapsedMilliseconds / 1000).ToString());
            Console.ForegroundColor = ConsoleColor.White;
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