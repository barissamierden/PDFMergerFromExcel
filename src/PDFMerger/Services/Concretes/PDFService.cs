using Microsoft.Office.Interop.Excel;
using PDFMerger.Models;
using PDFMerger.Services.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace PDFMerger.Services.Concretes
{
    public class PDFService : IPDFService
    {
        public async Task Merge(Application? excelApp, string path, SourceType sourceType)
        {
            var sw = new Stopwatch();

            sw.Start();

            List<PdfDocument> pdfDocuments = new();

            if (sourceType == SourceType.Excel)
            {
                BuildPdfsByExcel(excelApp, path);
            }
            else if (sourceType == SourceType.Directory)
            {
                BuildPdfsByDirectory(path);
            }

            sw.Stop();

            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.Clear();

            var allDoneText = "ALL DONE";
            Console.SetCursorPosition((Console.WindowWidth - allDoneText.Length) / 2, Console.CursorTop);

            Console.ForegroundColor = ConsoleColor.Green;
            await Console.Out.WriteLineAsync(allDoneText);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");

            var outputText = "Total Elapsed Time: " + (sw.ElapsedMilliseconds).ToString() + " ms";
            Console.SetCursorPosition((Console.WindowWidth - outputText.Length) / 2, Console.CursorTop);
            
            Console.ForegroundColor = ConsoleColor.Green;
            await Console.Out.WriteLineAsync(outputText);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void BuildPdfsByDirectory(string path)
        {
            List<string> directoryPathsToExplore = new() { path };

            List<string> tempPaths = new();

            List<string> directoryPaths = new() { path };

            again:

            foreach (var directoryPathToExplore in directoryPathsToExplore)
            {
                var directories = GetDirectories(directoryPathToExplore, "*");
                tempPaths.AddRange(directories);
                directoryPaths.AddRange(directories);
            }

            if (tempPaths.Count > 0)
            {
                directoryPathsToExplore.Clear();
                directoryPathsToExplore.AddRange(tempPaths);
                tempPaths.Clear();

                goto again;
            }

            foreach (var directoryPath in directoryPaths)
            {
                List<PdfDocument> pdfDocuments = new();

                var pdfFilePathsArr = GetPdfFilesByDirectoryPath(directoryPath);

                if (pdfFilePathsArr.Length > 0)
                {
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
                            outPdf.Save(Path.Combine(directoryPath, $"MergedPdf{counter.ToString()}.pdf"));
                            counter++;
                            outPdf = null;
                            outPdf = new PdfDocument();
                            pdfCounter = 0;
                        }

                        pdfCounter++;
                    }
                }
            }
        }

        private void BuildPdfsByExcel(Application? excelApp, string path)
        {
            excelApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
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
        }

        private void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }

        public static List<string> GetDirectories(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.AllDirectories)
        {
            if (searchOption == SearchOption.TopDirectoryOnly)
                return Directory.GetDirectories(path, searchPattern).ToList();

            var directories = new List<string>(GetDirectories(path, searchPattern));

            for (var i = 0; i < directories.Count; i++)
                directories.AddRange(GetDirectories(directories[i], searchPattern));

            return directories;
        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        private string[] GetPdfFilesByDirectoryPath(string path)
        {
            return Directory.GetFiles(path, "*.pdf", SearchOption.TopDirectoryOnly);
        }
    }
}