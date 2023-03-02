using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Student Name version 0.1
    /// </author>
    public class BMI
    {
        public double Bmi { get; private set; }

        public void Run()
        {
            OutputHeading();
            Console.WriteLine("Select the measurement system you would like to use...");
            FirstMenu();
            


        }

        // FIRST HEADER
        private void OutputHeading()
        {
            Console.WriteLine("By Enkh-Amgalan 'Entwan' Enkhbayar");
            Console.WriteLine("\t");
        }

        // FIRST MENU
        public void FirstMenu()
        {
            Console.WriteLine("1. Metric units");
            Console.WriteLine("2. Imperial units");
            string choice;
            do
            {
                Console.WriteLine("\t");
                Console.WriteLine("Choose the unit of measurement > ");
                Console.Write("Answer : ");
                choice = Console.ReadLine();

                if (choice == "1" || choice.ToLower() == "metric")
                {
                    Metric();
                }
                else if (choice == "2" || choice.ToLower() == "imperial")
                {
                    Imperial();
                }

                if(choice != "1" && choice != "2")
                {
                    Console.WriteLine("Error! Please enter valid choice! ");
                }

            }
            while
            (
              choice != "1" && choice != "2" && choice != "metric" && choice != "imperial"
            );
        }
        public void Metric()
        {
            Console.WriteLine("\t");
            Console.WriteLine("Enter yout height in metres > ");
            Console.Write("Answer : ");
            string heightmStr = Console.ReadLine();
            double heightm = Convert.ToDouble(heightmStr);

            Console.WriteLine("\t");
            Console.WriteLine("Enter yout weight in kilograms > ");
            Console.Write("Answer : ");
            string weightmStr = Console.ReadLine();
            double weightm = Convert.ToInt32(weightmStr);

            double Bmi = weightm / (heightm * heightm);

            if (Bmi < 18.50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are underweight !");
            }
            else if (Bmi < 24.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are in normal range ! ");
            }
            else if (Bmi < 29.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are bit overweight ! ");
            }
            else if (Bmi < 34.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are in Obese Class 1 ! ");
            }
            else if (Bmi < 39.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are in Obese Class 2 ! ");
            }
            else if (Bmi >= 40)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are in Obese Class 3 ! ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t");
            Console.WriteLine("If you are Black, Asian or other minority ");
            Console.WriteLine("ethnic groups, you have a higher risk ");
            Console.WriteLine("Adults 23.0 or more are at increased risk");
            Console.WriteLine("Adults 27.5 or more are at high risk");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Imperial()
        {
            Console.WriteLine("\t");
            Console.WriteLine("Enter yout height in feet > ");
            Console.Write("Answer : ");
            string heightFeetStr = Console.ReadLine();
            double heightFeet = Convert.ToDouble(heightFeetStr);

            Console.WriteLine("Enter yout height in inches > ");
            Console.Write("Answer : ");
            string heightInchStr = Console.ReadLine();
            double heightInch = Convert.ToDouble(heightInchStr);

            Console.WriteLine("\t");
            Console.WriteLine("Enter yout weight in stones > ");
            Console.Write("Answer : ");
            string weightStonesStr = Console.ReadLine();
            double weightStones = Convert.ToDouble(weightStonesStr);

            Console.WriteLine("Enter yout weight in pounds > ");
            Console.Write("Answer : ");
            string weightPStr = Console.ReadLine();
            double weightP = Convert.ToDouble(weightPStr);

            double height = heightFeet * 12 + heightInch;
            double weight = weightStones * 14 + weightP;

            double Bmi = weight / (height * height) * 703;
        
         
            if (Bmi < 18.50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are underweight !");
            }
            else if (Bmi < 24.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are in normal range ! ");
            }
            else if (Bmi < 29.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are bit overweight ! ");
            }
            else if (Bmi < 34.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are in Obese Class 1 ! ");
            }
            else if (Bmi < 39.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are in Obese Class 2 ! ");
            }
            else if (Bmi >= 40)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi + ", You are in Obese Class 3 ! ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t");
            Console.WriteLine("If you are Black, Asian or other minority ");
            Console.WriteLine("ethnic groups, you have a higher risk ");
            Console.WriteLine("Adults 23.0 or more are at increased risk");
            Console.WriteLine("Adults 27.5 or more are at high risk");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        }  
    }
		
	