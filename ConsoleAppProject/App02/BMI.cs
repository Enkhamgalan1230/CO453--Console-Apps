using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This class will calcuate BMI for people and users are allowed to choose from two options which are imperial unit or metric unit. 
    /// </summary>
    /// <author>
    /// Enkh-Amgalan Enkhbayar
    /// </author>
    public class BMI
    {
        // Declaring variables so i can use it in different methods
        public double Bmi { get; private set; }
        double weightm;
        double heightm;
        double heightFeet;
        double heightInch;
        double weightStones;
        double weightP;
        double Bmi2;

        // RUNNING THE METHODS THAT I CREATED
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

            // USER WILL CHOOSE THE UNIT HERE
            do
            {
                Console.WriteLine("\t");
                Console.WriteLine("Choose the unit of measurement > ");
                Console.Write("Answer : ");
                choice = Console.ReadLine();

                if (choice == "1" || choice.ToLower() == "metric")
                {
                    Metric();
                    MetricCalculation();
                    OutputMetric();
                }
                else if (choice == "2" || choice.ToLower() == "imperial")
                {
                    Imperial();
                    ImperialCalculation();
                    OutputImperial();
                }
                
                // ERROR MESSAGE IF INVALID INPUT IS ENTERED

                if(choice != "1" && choice != "2")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter valid choice! ");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            }
            while
            (
              choice != "1" && choice != "2" && choice != "metric" && choice != "imperial"
            );
        }
        public double Metric()
        {
            // DECLARING LOCAL VARIABLES

            string heightmStr;
            string weightmStr;
            bool isValid;

            // THIS SECTION WILL ASK HEIGHT IN METRES
            // IF INVALID INPUT IS ENTERED IT WILL SHOW ERROR
            do
            {
                Console.WriteLine("\t");
                Console.WriteLine("Enter your height in metres > ");
                Console.Write("Answer : ");
                heightmStr = Console.ReadLine();
                try
                {
                    heightm = Convert.ToDouble(heightmStr);
                    isValid = true;

                }
                catch (Exception)
                {
                    isValid = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                if  (heightm <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            } while (heightm <= 0);

            // THIS SECTION WILL ASK WEIGHT IN KILOGRAMS
            // IF INVALID INPUT IS ENTERED IT WILL SHOW ERROR

            do
            {
                Console.WriteLine("\t");
                Console.WriteLine("Enter your weight in kilograms > ");
                Console.Write("Answer : ");
                weightmStr = Console.ReadLine();
                try
                {
                    weightm = Convert.ToDouble(weightmStr);
                    isValid = true;

                }
                catch (Exception)
                {
                    isValid = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                if (weightm <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            } while (weightm <= 0);

            return 0;
        }

        // CALCULATION FOR METRIC
        public void MetricCalculation()
        {
            Bmi = weightm / (heightm * heightm);
        }

        // OUTPUT FOR METRIC 
        public void OutputMetric()
        {


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
            // DECLARING LOCAL VARIABLES

            string heightFeetStr;
            string heightInchStr;
            string weightStonesStr;
            string weightPStr;
            bool isValid;

            // THIS SECTION WILL ASK HEIGHT IN FEET
            // IF INVALID INPUT IS ENTERED IT WILL SHOW ERROR

            do
            {
                Console.WriteLine("\t");
                Console.WriteLine("Enter your height in feet > ");
                Console.Write("Answer : ");
                heightFeetStr = Console.ReadLine();
                try
                {
                    heightFeet = Convert.ToDouble(heightFeetStr);
                    isValid = true;

                }
                catch (Exception)
                {
                    isValid = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                if ( heightFeet <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            } while (heightFeet <= 0);

            // THIS SECTION WILL ASK HEIGHT IN INCHES
            // IF INVALID INPUT IS ENTERED IT WILL SHOW ERROR
            
            do
            {
                Console.WriteLine("\t");
                Console.WriteLine("Enter your height in inches > ");
                Console.Write("Answer : ");
                heightInchStr = Console.ReadLine();
                try
                {
                    heightInch = Convert.ToDouble(heightInchStr);
                    isValid = true;

                }
                catch (Exception)
                {
                    isValid = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                if (heightInch <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            } while (heightInch <= 0);

            // THIS SECTION WILL ASK WEIGHT IN STONES
            // IF INVALID INPUT IS ENTERED IT WILL SHOW ERROR

            do
            {
                Console.WriteLine("\t");
                Console.WriteLine("Enter your weight in stones > ");
                Console.Write("Answer : ");
                weightStonesStr = Console.ReadLine();
                try
                {
                    weightStones = Convert.ToDouble(weightStonesStr);
                    isValid = true;

                }
                catch (Exception)
                {
                    isValid = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                if (weightStones <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            } while (weightStones <= 0);

            // THIS SECTION WILL ASK WEIGHT IN POUNDS
            // IF INVALID INPUT IS ENTERED IT WILL SHOW ERROR

            do
            {
                Console.WriteLine("\t");
                Console.WriteLine("Enter yout weight in pounds > ");
                Console.Write("Answer : ");
                weightPStr = Console.ReadLine();
                try
                {
                    weightP = Convert.ToDouble(weightPStr);
                    isValid = true;

                }
                catch (Exception)
                {
                    isValid = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                if (weightP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" INVALID NUMBER!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            } while (weightP <= 0);

        }  
        
        // CALCULATION FOR IMPERIAL

        public void ImperialCalculation()
        {
            double height = heightFeet * 12 + heightInch;
            double weight = weightStones * 14 + weightP;

            Bmi2 = weight / (height * height) * 703;
        }

        // IMPERIAL OUTPUT

        public void OutputImperial()
        {
            if (Bmi2 < 18.50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi2 + ", You are underweight !");
            }
            else if (Bmi2 < 24.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi2 + ", You are in normal range ! ");
            }
            else if (Bmi2 < 29.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi2 + ", You are bit overweight ! ");
            }
            else if (Bmi2 < 34.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi2 + ", You are in Obese Class 1 ! ");
            }
            else if (Bmi2 < 39.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi2 + ", You are in Obese Class 2 ! ");
            }
            else if (Bmi2 >= 40)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your BMI is " + Bmi2 + ", You are in Obese Class 3 ! ");
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
		
	