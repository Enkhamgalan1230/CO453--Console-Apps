using ConsoleAppProject.App01;
using ConsoleAppProject.App03;
using ConsoleAppProject.Helpers;
using System;
using System.Xml.Serialization;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Derek Peacock 05/02/2022
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

            DistanceConverter converter = new DistanceConverter();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Console App Project");
            Console.WriteLine("  Choose the application by entering the number ");
            Console.WriteLine(" 1. Distance Converter ");
            string choiceStr = Console.ReadLine();
            int choice = 0;
            if (!int.TryParse(choiceStr, out choice) || (choice < 1 || choice > 4))
            {
                Console.WriteLine("Error! Try again");
                return;
            }
            if (choice == 1)
            {
                converter.Run();
            }
            
            
        }
    }
}
