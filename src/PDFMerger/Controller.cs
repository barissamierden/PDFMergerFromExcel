using Microsoft.Office.Interop.Excel;
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
            Application excelApp = new Application();

            Console.Write("Please enter the excel files path: ");
            var excelFilePath = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(excelFilePath))
                await pdfService.Merge(excelApp, excelFilePath);
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
