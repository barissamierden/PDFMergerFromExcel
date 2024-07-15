using Microsoft.Office.Interop.Excel;
using PDFMerger;
using PDFMerger.Services.Concretes;
using PDFMerger.Services.Interfaces;
using System.Net.Http.Headers;

retry:

var controller = new Controller();

Console.Write("UserName: ");
var userName = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(userName))
{
    Console.Write("Password: ");
    var password = controller.GetConsolePassword();

    if (!string.IsNullOrWhiteSpace(password))
    {
        IUserService userService = new UserService();

        var result = await userService.ValidateUser(userName, password);

        if (result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have successfully logged in!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This application merges every 51 pdf files by order which are given by an excel file.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");

            await controller.Run();
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect credentials! Please try again!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            goto retry;
        }
    }
}