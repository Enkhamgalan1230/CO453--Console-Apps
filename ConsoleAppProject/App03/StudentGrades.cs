using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        // Const

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
        public Grades[] Grades { get; set; }

        private readonly string[] Classification = new string[] {"First Class", "Upper Second Class",
        "Lower Second Class", "Third Class", "Fail",};

        public double Mean { get; set; }   

        public int Minimum { get; set; }    

        public int Maximum { get; set; }

        public void Run()
        {
            Menu();
        }

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
        public void InputMarks()
        {
            for (int i = 0; i < Students.Length; i++  )
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
                    else if (mark> 100)
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
                        validInput= true;
                    }

                }
                Marks[i] = mark;
              
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You have successfully completed marks");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Menu();


        }
        public void OutputMarks()
        {
            Console.WriteLine("N0.".PadRight(5) + "Names".PadRight(13) + "Marks".PadRight(9) + "Grade");
            Console.WriteLine("===".PadRight(5) + "======".PadRight(13) + "====".PadRight(9) + "====");
            int students = 0;
            for (int i = 0; i< Students.Length; i++)
            {
                int mark = Marks[i];
                Grades grade = ConvertMarktoGrade(mark);
                string studentNumber= (i+1).ToString();
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

        public void OutputGradeProfile()
        {
            CalculateGradeProfile();
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{GradeProfile[i]}% - {Classification[i]}");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
            Menu();
        }

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
        public void CalculateMean()
        {
            int total = 0;

            Maximum = Marks[0];
            Minimum = Marks[0];

            foreach (int mark in Marks)
            {
                if (mark > MAX_MARK)
                {
                    Maximum = mark;
                }
                else if (mark < MIN_MARK)
                {
                    Minimum = mark;
                }

                total += mark;
                Mean = total / Students.Length;

            }
        }
        public void CalculateMinMax()
        {
               Minimum = Marks[0];
               Maximum = Marks[0];

               int total = 0;

               foreach (int mark in Marks)
               {
                   total += mark;

                   if (mark > Maximum)
                   {
                       Maximum = mark;
                   }
                   else if (mark < Minimum)
                   {
                       Minimum = mark;
                   }

               }

                Mean = total / Marks.Length;
        }
        public void CalculateGradeProfile()
        {
            GradeProfile = new int[5];

            foreach (var grade in Grades)
            {
                if (grade == App03.Grades.F)
                    GradeProfile[0]++;

                else if (grade == App03.Grades.D)
                    GradeProfile[1]++;

                else if (grade == App03.Grades.C)
                    GradeProfile[2]++;

                else if (grade == App03.Grades.B)
                    GradeProfile[3]++;

                else if (grade == App03.Grades.A)
                    GradeProfile[4]++;

            }

            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = GradeProfile[i] * (100 / Students.Length);
            }
        }
        public void CalculateGrades()
        {
            Grades = new Grades[Students.Length];

            for (int i = 0; i < Marks.Length; i++)
            {
                if (Marks[i] is >= 0 and < 40)
                    Grades[i] = App03.Grades.F;

                else if (Marks[i] is >= 40 and < 50)
                    Grades[i] = App03.Grades.D;

                else if (Marks[i] is >= 50 and < 60)
                    Grades[i] = App03.Grades.C;

                else if (Marks[i] is >= 60 and < 70)
                    Grades[i] = App03.Grades.B;

                else if (Marks[i] is >= 70 and < 100)
                    Grades[i] = App03.Grades.A;

            }
        }


    }
}



