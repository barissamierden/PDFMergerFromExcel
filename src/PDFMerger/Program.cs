using Microsoft.Office.Interop.Excel;
using PDFMerger.Services.Concretes;
using PDFMerger.Services.Interfaces;

Console.WriteLine("This application merges every 51 pdf files by order which are given by an excel file.");

await Run();


async Task Run()
{
    IPDFService PDFService = new PDFService();
    Application excelApp = new Application();

    Console.Write("Please enter the excel files path: ");
    var excelFilePath = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(excelFilePath))
        await PDFService.Merge(excelApp, excelFilePath);
}