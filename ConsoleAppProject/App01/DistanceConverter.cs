using ConsoleAppProject.App01;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This class will convert distance units into other units while allowing users to choose the unit measurements. 
    /// </summary>
    /// <author>
    /// Enkh-Amgalan Enkhbayar
    /// </author>
    public class DistanceConverter
    {
         // CONSTANTS 
        public static double FEET_IN_MILE = 5280;
        public static double METERS_IN_MILE = 1609.34;
        public static double METERS_IN_FEET = 3.281;
        public static double METERS_IN_KILOMETERS = 1000;
        public static double CENTIMETERS_IN_KILOMETERS = 100000;
        public static double MILES_IN_KILOMETERS = 1.609;
        public static double YARD_IN_KILOMETERS = 1094;
        public static double FEET_IN_KILOMETERS = 3281;
        public static double INCHES_IN_KILOMETERS = 39370;
        public static double CENTIMETERS_IN_METERS = 100;
        public static double MILES_IN_METERS = 1609;
        public static double YARD_IN_METERS = 1.094;
        public static double FEET_IN_METERS = 3.281;
        public static double INCHES_IN_METERS = 39.37;
        public static double MILES_IN_CENTIMETERS = 160900;
        public static double YARD_IN_CENTIMETERS = 91.44;
        public static double FEET_IN_CENTIMETERS = 30.48;
        public static double INCHES_IN_CENTIMETERS = 2.54;
        public static double MILES_IN_YARD = 1760;
        public static double FEET_IN_YARD = 3;
        public static double INCHES_IN_YARD = 36;
        public static double MILES_IN_INCHES = 63360;
        public static double FEET_IN_INCHES = 12;
        public static double MILES_IN_FEET = 5280;

         // DECLARING THE VARIABLES 
        public double miles, meters, feet, kilometers, centimeters, yard, inches;
        double fromDis;
        double toDis;
        string fromUnit;
        string toUnit;
        
         // RUNNING THE METHODS THAT I CREATED
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



         // FIRST HEADER
        private void OutputHeading()
        {
            Console.WriteLine("Distance Converter By Enkh-Amgalan 'Entwan' Enkhbayar");
            Console.WriteLine("\t");
        }
         // FIRST MENU
        public string FromUnitMenu()
        {
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Meters");
            Console.WriteLine("3. Feet");
            Console.WriteLine("4. Kilometers");
            Console.WriteLine("5. Centimeters");
            Console.WriteLine("6. Yard");
            Console.WriteLine("7. Inches");
            string unit;

             // RETURNING THE CHOICES
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
                else if (unit == "4" || unit.ToLower() == "kilometers")
                {
                    return "kilometers";
                }
                else if (unit == "5" || unit.ToLower() == "centimeters")
                {
                    return "centimeters";
                }
                else if (unit == "6" || unit.ToLower() == "yard")
                {
                    return "yard";
                }
                else if (unit == "7" || unit.ToLower() == "inches")
                {
                    return "inches";
                }
                if (unit != "1" || unit != "2" || unit != "3" || unit != "4" || unit != "5" || unit != "6" || unit != "7" ||
              unit != "miles" || unit != "meters" || unit != "feet")
                {
                    Console.WriteLine("Invalid unit, try again!");
                }
            }
             // CHECKING POSSIBLE ANSWERS
            while
            (
              unit != "1" || unit != "2" || unit != "3" || unit != "4" || unit != "5" || unit != "6" || unit != "7" ||
              unit != "miles" || unit != "meters" || unit != "feet" || unit != "kilometers" || unit != "centimeters" || unit != "yard" || unit != "inches"
            );
            
         
            return null;
        }

         // SECOND MENU 
        public string ToUnitMenu()
        {
            Console.WriteLine("Choose the unit of measurement ");
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Meters");
            Console.WriteLine("3. Feet");
            Console.WriteLine("4. Kilometers");
            Console.WriteLine("5. Centimeters");
            Console.WriteLine("6. Yard");
            Console.WriteLine("7. Inches");
            string convert;
             // RETURNING THE CHOICES
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
                else if (convert == "4" || convert.ToLower() == "kilometers")
                {
                    return "kilometers";
                }
                else if (convert == "5" || convert.ToLower() == "centimeters")
                {
                    return "centimeters";
                }
                else if (convert == "6" || convert.ToLower() == "yard")
                {
                    return "yard";
                }
                else if (convert == "7" || convert.ToLower() == "inches")
                {
                    return "inches";
                }
                if ((convert != "1" || convert != "2" || convert != "3" || convert != "4" || convert != "5" || convert != "6" || convert != "7" ||
               convert != "miles" || convert != "meters" || convert != "feet"))
                {
                    Console.WriteLine("Invalid unit, try again!");
                }
            }
             // CHECKING POSSIBLE ANSWERS
            while 
            (
              convert != "1" || convert != "2" || convert != "3" || convert != "4" || convert != "5" || convert != "6" || convert != "7" || 
              convert != "miles" || convert != "meters" || convert != "feet" || convert != "kilometers" || convert != "centimeters" || convert != "yard" || convert != "inches"
            );
               
            return null;
        }
         // ASKING USER FOR INPUT
        public int InputDistance(string prompt)
        {
            Console.WriteLine("Please enter the number of  " + prompt);
            return Convert.ToInt32(Console.ReadLine());
        }

         // CONVERTING PROCESS
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
            else if (fromUnit == "meters" && toUnit == "kilometers")
            {
                toDis = fromDis * METERS_IN_KILOMETERS;
            }
            else if (fromUnit == "centimeters" && toUnit == "kilometers")
            {
                toDis = fromDis * CENTIMETERS_IN_KILOMETERS;
            }
            else if (fromUnit == "miles" && toUnit == "kilometers")
            {
                toDis = fromDis / MILES_IN_KILOMETERS ;
            }
            else if (fromUnit == "yard" && toUnit == "kilometers")
            {
                toDis = fromDis * YARD_IN_KILOMETERS;
            }
            else if (fromUnit == "feet" && toUnit == "kilometers")
            {
                toDis = fromDis * FEET_IN_KILOMETERS;
            }
            else if (fromUnit == "inches" && toUnit == "kilometers")
            {
                toDis = fromDis * INCHES_IN_KILOMETERS;
            }
            else if (fromUnit == "kilometers" && toUnit == "kilometers")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "kilometers" && toUnit == "meters")
            {
                toDis = fromDis / METERS_IN_KILOMETERS;
            }
            else if (fromUnit == "centimeters" && toUnit == "meters")
            {
                toDis = fromDis * CENTIMETERS_IN_METERS;
            }
            else if (fromUnit == "yard" && toUnit == "meters")
            {
                toDis = fromDis * YARD_IN_METERS;
            }
            else if (fromUnit == "feet" && toUnit == "meters")
            {
                toDis = fromDis / METERS_IN_FEET;
            }
            else if (fromUnit == "inches" && toUnit == "meters")
            {
                toDis = fromDis * INCHES_IN_METERS;
            }
            else if (fromUnit == "feet" && toUnit == "meters")
            {
                toDis = fromDis / METERS_IN_FEET;
            }
            else if (fromUnit == "meters" && toUnit == "meters")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "kilometers" && toUnit == "centimeters")
            {
                toDis = fromDis / CENTIMETERS_IN_KILOMETERS;
            }
            else if (fromUnit == "meters" && toUnit == "centimeters")
            {
                toDis = fromDis / CENTIMETERS_IN_METERS;
            }
            else if (fromUnit == "miles" && toUnit == "centimeters")
            {
                toDis = fromDis / MILES_IN_CENTIMETERS;
            }
            else if (fromUnit == "yard" && toUnit == "centimeters")
            {
                toDis = fromDis / YARD_IN_CENTIMETERS;
            }
            else if (fromUnit == "feet" && toUnit == "centimeters")
            {
                toDis = fromDis / FEET_IN_CENTIMETERS;
            }
            else if (fromUnit == "inches" && toUnit == "centimeters")
            {
                toDis = fromDis / INCHES_IN_CENTIMETERS;
            }
            else if (fromUnit == "centimeters" && toUnit == "centimeters")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "meters" && toUnit == "yard")
            {
                toDis = fromDis / YARD_IN_METERS;
            }
            else if (fromUnit == "kilometers" && toUnit == "yard")
            {
                toDis = fromDis / YARD_IN_KILOMETERS;
            }
            else if (fromUnit == "centimeters" && toUnit == "yard")
            {
                toDis = fromDis / YARD_IN_CENTIMETERS;
            }
            else if (fromUnit == "miles" && toUnit == "yard")
            {
                toDis = fromDis / MILES_IN_YARD;
            }
            else if (fromUnit == "feet" && toUnit == "yard")
            {
                toDis = fromDis *FEET_IN_YARD;
            }
            else if (fromUnit == "inches" && toUnit == "yard")
            {
                toDis = fromDis * INCHES_IN_YARD;
            }
            else if (fromUnit == "yard" && toUnit == "yard")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "kilometers" && toUnit == "inches")
            {
                toDis = fromDis / INCHES_IN_KILOMETERS;
            }
            else if (fromUnit == "meters" && toUnit == "inches")
            {
                toDis = fromDis / INCHES_IN_METERS;
            }
            else if (fromUnit == "centimeters" && toUnit == "inches")
            {
                toDis = fromDis * INCHES_IN_CENTIMETERS;
            }
            else if (fromUnit == "miles" && toUnit == "inches")
            {
                toDis = fromDis / MILES_IN_INCHES;
            }
            else if (fromUnit == "yard" && toUnit == "inches")
            {
                toDis = fromDis / INCHES_IN_YARD;
            }
            else if (fromUnit == "feet" && toUnit == "inches")
            {
                toDis = fromDis / FEET_IN_INCHES;
            }
            else if (fromUnit == "inches" && toUnit == "inches")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "kilometers" && toUnit == "feet")
            {
                toDis = fromDis / FEET_IN_KILOMETERS;
            }
            else if (fromUnit == "centimeters" && toUnit == "feet")
            {
                toDis = fromDis * FEET_IN_CENTIMETERS;
            }
            else if (fromUnit == "yard" && toUnit == "feet")
            {
                toDis = fromDis / FEET_IN_YARD;
            }
            else if (fromUnit == "inches" && toUnit == "feet")
            {
                toDis = fromDis * FEET_IN_INCHES;
            }
            else if (fromUnit == "meters" && toUnit == "feet")
            {
                toDis = fromDis / YARD_IN_METERS;
            }
            else if (fromUnit == "feet" && toUnit == "feet")
            {
                toDis = fromDis;
            }
            else if (fromUnit == "kilometers" && toUnit == "miles")
            {
                toDis = fromDis * MILES_IN_KILOMETERS;
            }
            else if (fromUnit == "centimeters" && toUnit == "miles")
            {
                toDis = fromDis * MILES_IN_CENTIMETERS;
            }
            else if (fromUnit == "yard" && toUnit == "miles")
            {
                toDis = fromDis * MILES_IN_YARD;
            }
            else if (fromUnit == "inches" && toUnit == "miles")
            {
                toDis = fromDis * MILES_IN_INCHES;
            }

        }

         //OUTPUT
        public void Output() 
        {
            Console.WriteLine(fromDis + " "+ fromUnit + " is " + toDis + " " + toUnit + " !" );
        }
    }
}

    




