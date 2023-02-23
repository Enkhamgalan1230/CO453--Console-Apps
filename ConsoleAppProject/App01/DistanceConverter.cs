using ConsoleAppProject.App01;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Derek version 0.1
    /// </author>
    public class DistanceConverter
    {
        public static double FEET_IN_MILE = 5280;
        public static double METERS_IN_MILE = 1609.34;
        public static double METERS_IN_FEET = 3.281;
        public double miles, meters, feet;
        double fromDis;
        double toDis;
        string fromUnit;
        string toUnit;
        public void Run()
        {
            OutputHeading();
            Console.WriteLine("Select the unit you would like to convert...");
            fromUnit = FromUnitMenu();
            Console.WriteLine("Select the unit you would like to convert it to...");
            toUnit = ToUnitMenu();

            fromDis = InputDistance(fromUnit);
            ConvertDis();
            Output();
        }




        private void OutputHeading()
        {
            Console.WriteLine("Distance Converter By Entwan Enkhbayar");
            Console.WriteLine("\t");
        }

        public string FromUnitMenu()
        {
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Meters");
            Console.WriteLine("3. Feet");
            string unit;

            do
            {
                Console.WriteLine("Choose the unit of measurement > ");
                unit = Console.ReadLine();
                if (unit == "1" || unit.ToLower() == "miles")
                {
                    return "miles";
                }
                else if (unit == "2" || unit.ToLower() == "meters")
                {
                    return "meters";
                }
                else if (unit == "3" || unit.ToLower() == "feet")
                {
                    return "feet";
                }
                if(unit != "1" || unit != "2" || unit != "3" || unit != "4" || unit != "5" || unit != "6" ||
              unit != "miles" || unit != "meters" || unit != "feet")
                {
                    Console.WriteLine("Invalid unit, try again!");
                }
            }
            while
            (
              unit != "1" || unit != "2" || unit != "3" || unit != "4" || unit != "5" || unit != "6" ||
              unit != "miles" || unit != "meters" || unit != "feet"
            );
            
         
            return null;
        }


        public string ToUnitMenu()
        {
            Console.WriteLine("Choose the unit of measurement ");
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Meters");
            Console.WriteLine("3. Feet");
            string convert;
            do
            {
                Console.WriteLine("Choose the unit of measurement > ");
                convert = Console.ReadLine();
                if (convert == "1" || convert.ToLower() == "miles")
                {
                    return "miles";
                }
                else if (convert == "2" || convert.ToLower() == "meters")
                {
                    return "meters";
                }
                else if (convert == "3" || convert.ToLower() == "feet")
                {
                    return "feet";
                }
                if((convert != "1" || convert != "2" || convert != "3" || convert != "4" || convert != "5" || convert != "6" ||
               convert != "miles" || convert != "meters" || convert != "feet"))
                {
                    Console.WriteLine("Invalid unit, try again!");
                }
            }
            while (convert != "1" || convert != "2" || convert != "3" || convert != "4" || convert != "5" || convert != "6" ||
               convert != "miles" || convert != "meters" || convert != "feet");
               
            return null;
        }

        public int InputDistance(string prompt)
        {
            Console.WriteLine("Please enter the number of  " + prompt);
            return Convert.ToInt32(Console.ReadLine());
        }


        public void ConvertDis()
        {
            if (fromUnit == "miles" && toUnit == "meters")
            {
                toDis = fromDis * METERS_IN_MILE;
            }
            else if (fromUnit == "miles" && toUnit == "miles")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "miles" && toUnit == "feet")
            {
                toDis = fromDis * FEET_IN_MILE;
            }
            else if (fromUnit == "meters" && toUnit == "miles")
            {
                toDis = fromDis / FEET_IN_MILE;
            }
            else if (fromUnit == "meters" && toUnit == "meters")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "meters" && toUnit == "feet")
            {
                toDis = fromDis / METERS_IN_FEET;
            }
            else if (fromUnit == "feet" && toUnit == "miles")
            {
                toDis = fromDis / FEET_IN_MILE;
            }
            else if (fromUnit == "feet" && toUnit == "feet")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "feet" && toUnit == "meters")
            {
                toDis = fromDis / METERS_IN_FEET;
            }
        }
            public void Output() 
            {
            Console.WriteLine(fromDis + " "+ fromUnit + " is " + toDis + " " + toUnit + " !" );
            }
    }
}

    




