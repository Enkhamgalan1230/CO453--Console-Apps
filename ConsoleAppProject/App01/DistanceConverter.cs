using ConsoleAppProject.App01;
using System;

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
            Console.WriteLine("Select the unit you would like to convert...");
            fromUnit = FromUnitMenu();
            Console.WriteLine("Select the unit you would like to convert it to...");
            toUnit = ToUnitMenu();

            fromDis = InputDistance(fromUnit);
            ConvertDis();
        }




        private void OutputHeading()
        {
            Console.Write("Distance Converter By Entwan Enkhbayar");
        }

        public string FromUnitMenu()
        {
            Console.WriteLine("Which unit would you like to convert ?");
            Console.WriteLine("1. Miles");
            Console.WriteLine("2. Meters");
            Console.WriteLine("3. Feet");

            string unitSt = Console.ReadLine();
            int unit = 0;

            if (!int.TryParse(unitSt, out unit) || (unit < 1 || unit > 6))
            {
                Console.WriteLine("Please enter valid unit choice from 1 to 3.");
               
            }
            if (unit == 1)
            {
                return "miles";
            }
            else if (unit == 2)
            {
                return "meters";
            }
            else if (unit == 3)
            {
                return "feet";
            }
            return null;
        }


        public string ToUnitMenu() 
        {
                Console.WriteLine("Which unit would you like to convert the distance to ?");
                Console.WriteLine("1. Miles");
                Console.WriteLine("2. Meters");
                Console.WriteLine("3. Feet");

                string convertSt = Console.ReadLine();
                int convert = 0;

                if (!int.TryParse(convertSt, out convert) || (convert < 1 || convert > 6))
                {
                    Console.WriteLine("Please enter valid unit choice from 1 to 3.");
                
                }
                if (convert == 1)
                {
                    return "miles";
                }
                else if (convert == 2)
                {
                    return "meters";
                }
                else if (convert == 3)
                {
                    return "feet";
                }
            return null;
        }

        public int InputDistance(string prompt)
        {
            Console.WriteLine("Please enter the number of  " + prompt);
            return Convert.ToInt32(Console.ReadLine());
        }


        public void ConvertDis()
        {
            if (fromUnit == "miles" || toUnit == "meters")
            {
                toDis = fromDis * METERS_IN_MILE;
            }
            if (fromUnit == "miles" || toUnit == "feet")
            {
                toDis = fromDis * FEET_IN_MILE;
            }
            if (fromUnit == "meters" || toUnit == "miles")
            {
                toDis = fromDis / FEET_IN_MILE;
            }
            if (fromUnit == "meters" || toUnit == "feet")
            {
                toDis = fromDis / METERS_IN_FEET;
            }
            if (fromUnit == "feet" || toUnit == "miles")
            {
                toDis = fromDis / FEET_IN_MILE;
            }
            if (fromUnit == "feet" || toUnit == "meters")
            {
                toDis = fromDis / METERS_IN_FEET;
            }

        }


        }

    }




