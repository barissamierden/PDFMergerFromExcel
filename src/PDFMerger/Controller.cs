using Microsoft.Office.Interop.Excel;
using PDFMerger.Models;
using PDFMerger.Services.Concretes;
using PDFMerger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PDFMerger
{
    public class Controller
    {
        public async Task Run()
        {
            IPDFService pdfService = new PDFService();
            Application? excelApp = new Application(); ;

        retry:
            Console.WriteLine("Please choose a file path source below:");
            Console.WriteLine("   1. From an Excel file");
            Console.WriteLine("   2. From directory path");

            var selectedFileSourceKey = Console.ReadKey(true).KeyChar;

            if (selectedFileSourceKey != '1' && selectedFileSourceKey != '2')
            {
                Console.Clear();

                goto retry;
            }

            Console.Clear();

            if (selectedFileSourceKey == '1')
            {
                Console.Write("Please enter the Excel file path: ");
            }
            else
            {
                Console.Write("Please enter the directory path: ");
            }

            var path = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(path))
                await pdfService.Merge(excelApp, path.Trim().Replace("\"", ""), (SourceType)(Convert.ToInt32((selectedFileSourceKey).ToString())));
        }

        public string GetConsolePassword()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }

                Console.Write('*');
                sb.Append(cki.KeyChar);
            }

            return sb.ToString();
        }
    }
}
