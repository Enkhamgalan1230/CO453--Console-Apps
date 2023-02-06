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
        public static double KILOMETERS_IN_MILE = 1.609;
        public static double INCHES_IN_MILE = 63360;
        public static double CENTIMETERS_IN_MILE = 160900;
        public double miles, meters, feet, kilometers, yards, inches, centimeters;

        public void Run()
        {
            OutputHeading();

            // MILES INPUTS
            InputMiles();

            CalculateFeet();
            OutputFeet();
            CalculateMeters();
            OutputMeters();
            CalculateCentimeters();
            OutputCentimeters();
            CalculateKilometers();
            OutputKilometers();
            CalculateInches();
            OutputInches();

            // FEET INPUTS

            InputFeet();

            CalculateMiles2();
            OutputMiles2();
            CalculateMeters2();
            OutputMeters2();
            CalculateCentimeters2();
            OutputCentimeters2();
            CalculateKilometers2();
            OutputKilometers2();
            CalculateInches2();
            OutputInches2();
        }

        private void OutputHeading()
        {
            Console.Write("By Entwan Enkhbayar");
        }
    
         //MILE INPUTS

        private void InputMiles()
        {
            Console.Write("Please enter the number of miles ...");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

          //into feet
        private void CalculateFeet()
        {
            feet= miles*FEET_IN_MILE;
        }
        private void OutputFeet()
        {
            Console.Writeline(miles + "miles is " + feet + " feet!");
        }

          //into meters
        private void CalculateMeters()
        {
            meters = miles * METERS_IN_MILE;
        }
        private void OutputMeters()
        {
            Console.Writeline(miles + "miles is " + meters + " meters!");
        }

          //into kilometers
        private void CalculateKilometers()
        {
            kilometers = miles * KILOMETERS_IN_MILE;
        }
        private void OutputKilometers()
        {
            Console.Writeline(miles + "miles is " + kilometers + " kilometers!");
        }

          //into inches
        private void CalculateInches()
        {
            inches = miles * INCHES_IN_MILE;
        }
        private void OutputInches()
        {
            Console.Writeline(miles + "miles is " + inches + " inches!");
        }

        //into centimeters
        private void CalculateCentimeters()
        {
            centimeters = miles * CENTIMETERS_IN_MILE;
        }
        private void OutputCentimeters()
        {
            Console.Writeline(miles + "miles is " + centimeters + " centimeters!");
        }

        //FEET INPUTS

        

        
