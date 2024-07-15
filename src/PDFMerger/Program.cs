using Microsoft.Office.Interop.Excel;
using PDFMerger;
using PDFMerger.Services.Concretes;
using PDFMerger.Services.Interfaces;
using System.Net.Http.Headers;

var inCorrectTryCounter = 0;

retry:

if (inCorrectTryCounter > 0)
{

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Remaining retries: {5 - inCorrectTryCounter}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("");

    if (inCorrectTryCounter == 5) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Too many incorrect retries! Application is shutting down!");
        Console.ForegroundColor = ConsoleColor.White;
        return;
    }
}

var controller = new Controller();

Console.Write("UserName: ");
var userName = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(userName))
{
    Console.Write("Password: ");
    var password = controller.GetConsolePassword();

    if (password != null)
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
            inCorrectTryCounter++;
            goto retry;
        }
    }
}
else
{
    Console.Clear();
    goto retry;
}