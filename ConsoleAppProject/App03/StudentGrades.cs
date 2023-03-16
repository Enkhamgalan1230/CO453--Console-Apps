using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography;
using ConsoleAppProject.Helpers;
using System.Drawing;
using System.Web.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This class will allow user to mark students grade and see the results in table and see statistics.
    /// </summary>
    /// <author>
    /// Enkh-Amgalan Enkhbayar
    /// </author>
    public class StudentGrades
    {
        // CONSTANTS
        // DECLARED VARIABLES AND ARRAYS

        public const int FIRSTCLASS = 70;
        public const int UPPERSECONDCLASS = 60;
        public const int LOWERSECONDCLASS = 50;
        public const int THIRDCLASS = 40;
        public const int FAIL = 0;

        public const int MAXSTUDENTS = 10;
        public const int MAX_MARK = 100;
        public const int MIN_MARK = 0;

       
        public string[] Students { get; set; }

        public int[] Marks { get; set; }

        public int[] GradeProfile { get; set; }
        public int Total { get; set; }
        public Grades[] Grades { get; set; }

        
        public double Mean { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }
        

        // RUNNING THE METHOD THAT I CREATED
        public void Run()
        {
            Menu();
        }

        // USER MENU 
        // TEXT AND INT NUMBERS CAN BE AN INPUT 
        // IF THE INPUT IS MORE THAN A NUMBER '5', ERROR WILL BE DISPLAYED
        private void Menu()
        {
            Console.WriteLine("1. Input Marks");
            Console.WriteLine("2. Output Grades");
            Console.WriteLine("3. Output Statistics");
            Console.WriteLine("4. Output Grade Profile");
            Console.WriteLine("5. Quit");
            string choice;

            do
            {
                Console.WriteLine("\t");
                Console.Write("Answer : ");
                choice = Console.ReadLine();

                if (choice == "1" || choice.ToLower() == "input")
                {
                    InputMarks();
                }
                else if (choice == "2" || choice.ToLower() == "output grades")
                {
                    OutputMarks();
                }
                else if (choice == "3" || choice.ToLower() == "output statics")
                {
                    OutputStatistics();
                }
                else if (choice == "4" || choice.ToLower() == "output grade profile")
                {
                    OutputGradeProfile();
                }
                else if (choice == "5" || choice.ToLower() == "quit")
                {
                    Environment.Exit(0);
                }

                // ERROR MESSAGE IF INVALID INPUT IS ENTERED

                if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter valid choice! ");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            }
            while
           (
             choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5"
           );
        }

        // ADDING STRING NAMES TO MY STUDENTS ARRAY LIST
        //
        public StudentGrades()
        {
            Students = new string[]
            {
                "Entwan","Derik","Sihan","Nick","Cimo",
                "Rayan","Rafid","Ravoline","John","Henrey"
            };
            GradeProfile = new int[] { (int)App03.Grades.A + 1 };
            Marks = new int[Students.Length];

        }
        //
        // TAKING INT NUMBERS AS A MARKS AND STORING IT IN ARRAY LIST
        //
        public void InputMarks()
        {
            for (int i = 0; i < Students.Length; i++)
            {
                bool validInput = false;
                int mark = 0;
                while (!validInput)
                {
                    Console.WriteLine($" Enter mark for student '{Students[i]}' :");
                    Console.Write("Answer : ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out mark))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error! Enter valid number ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (mark > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error! Enter number between 0 and 100.");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (mark < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error! Enter number between 0 and 100.");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        validInput = true;
                    }

                }
                // THIS IS WHERE IT IS HELD
                Marks[i] = mark;

            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You have successfully completed marks");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.Green;
            // SHOWING THE MENU ONCE AGAIN AFTER THE KEYBOARD INPUT
            Console.ReadKey();
            Menu();


        }

        // OUTPUTING THE STORED ARRAYS
        // AT THE SAME TIME CHECKING THE MARKS AND CONVERTING IT TO GRADES
        // ADDITIONALLY ADDED SOME BARS SO IT LOOKS LIKE A TABLE
        // CREDIT TO : SIHAN (NEW LECTURER).
        public void OutputMarks()
        {
            Console.WriteLine("N0.".PadRight(5) + "Names".PadRight(13) + "Marks".PadRight(9) + "Grade");
            Console.WriteLine("===".PadRight(5) + "======".PadRight(13) + "====".PadRight(9) + "====");
            int students = 0;
            for (int i = 0; i < Students.Length; i++)
            {
                int mark = Marks[i];
                Grades grade = ConvertMarktoGrade(mark);
                string studentNumber = (i + 1).ToString();
                Console.Write($"{studentNumber}".PadRight(5));
                Console.Write($"{Students[i]}".PadRight(14));
                Console.Write($"{mark}".PadRight(8));
                Console.WriteLine($"{grade}");
                students++;

            }
            Console.WriteLine("===".PadRight(5) + "======".PadRight(13) + "====".PadRight(9) + "====");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"There are {students}" + " students. ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Menu();

        }

        // OUTPUT OF STATISTICS
        //
        public void OutputStatistics()
        {
            CalculateMean();
            CalculateMinMax();
            Console.WriteLine($"Mean Mark: {Mean}\nMinimum Mark: {Minimum}\nMaximum Mark: {Maximum}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Menu();
        }

        // 
        public void OutputGradeProfile()
        {
            int[] GradeCounts = new int[5];

            Console.WriteLine($" A (First Class) > {GradeCounts[0] / Marks.Length * 100}%");
            Console.WriteLine($" B (Upper Second Class) > {GradeCounts[1] / Marks.Length * 100}%");
            Console.WriteLine($" C (Lower Second Class) > {GradeCounts[2] / Marks.Length * 100}%");
            Console.WriteLine($" D (Third Class) > {GradeCounts[3] / Marks.Length * 100}%");
            Console.WriteLine($" F (Fail) > {GradeCounts[4] / Marks.Length * 100}%");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Menu();
        }

        // IN THIS METHOD IT WILL RETURN GRADES WHEN NUMBERS ARE ENTERED
        // I DON'T KNOW HOW TO EXPLAIN IT PROPERLY BUT 
        // IT IS CALLING AND TAKING INFO FROM GRADES.CS
        public Grades ConvertMarktoGrade(int mark)
        {
            if (mark < 40)
            {
                return App03.Grades.F;
            }

            else if (mark < 50)
            {
                return App03.Grades.D;
            }

            else if (mark < 60)
            {
                return App03.Grades.C;
            }

            else if (mark < 70)
            {
                return App03.Grades.B;
            }
            else
            {
                return App03.Grades.A;
            }
        }
        // MEANS IS CALCULATED HERE
        // ALL THE MARKS WILL BE ADDED AND DIVIDED BY TOTAL STUDENTS
        public void CalculateMean()
        {

            foreach (int mark in Marks)
            {
                Total += mark;
            }

            Mean = Total / Students.Length;
        }
        // MINIMUM AND MAXIMUM CALCULATION HERE
        //
        public void CalculateMinMax()
        {
            Minimum = Marks[0];
            Maximum = Marks[0];

            foreach (int mark in Marks)
            {

                if (mark > Maximum)
                {
                    Maximum = mark;
                }
                else if (mark < Minimum)
                {
                    Minimum = mark;
                }

            }

        }
        // CHECKING ALL THE MARKS AND IF IT IS BETWEEN IN THESE RANGES
        // THE COUNTER/LIST GOES UP
        public void CalculateGradeProfile()
        {
            int[] GradeCounts = new int[5];

            foreach (int mark in Marks)
            {
                if (mark >= 70)
                {
                    GradeCounts[0]++;
                }
                else if (mark >= 60)
                {
                    GradeCounts[1]++;
                }
                else if (mark >= 50)
                {
                    GradeCounts[2]++;
                }
                else if (mark >= 40)
                {
                    GradeCounts[3]++;
                }
                else
                {
                    GradeCounts[4]++;
                }
            }
            
        }
    }
}



