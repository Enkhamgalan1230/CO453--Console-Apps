using ConsoleAppProject.App03;
using System;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        
        int expectedOutput;
        
        private readonly StudentGrades
            grades = new StudentGrades();
        private readonly int[] Stats = new int[]
        {
            10,20,30,40,50,60,70,80,90,100
        };

        [TestMethod]
            public void TestZerotoGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(0);

                Assert.AreEqual(Grades.F, grade);
            }

            [TestMethod]
            public void Test39toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(39);

                Assert.AreEqual(Grades.F, grade);
            }

            [TestMethod]
            public void Test40toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(40);

                Assert.AreEqual(Grades.D, grade);
            }

            [TestMethod]
            public void Test49toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(49);

                Assert.AreEqual(Grades.D, grade);
            }

            [TestMethod]
            public void Test50toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(50);

                Assert.AreEqual(Grades.C, grade);
            }

            [TestMethod]
            public void Test59toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(59);

                Assert.AreEqual(Grades.C, grade);
            }

            [TestMethod]
            public void Test60toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(60);

                Assert.AreEqual(Grades.B, grade);
            }

            [TestMethod]
            public void Test69toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(69);

                Assert.AreEqual(Grades.B, grade);
            }

            [TestMethod]
            public void Test70toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(70);

                Assert.AreEqual(Grades.A, grade);
            }

            [TestMethod]
            public void Test100toGrade()
            {
                StudentGrades grades = new();

                Grades grade = grades.ConvertMarktoGrade(100);

                Assert.AreEqual(Grades.A, grade);
            }
            [TestMethod]
            public void TestMean()
            {

                 StudentGrades grades = new();
                 grades.Marks = Stats;
                 grades.CalculateMean();

                 expectedOutput = 55;

                 Assert.AreEqual(expectedOutput, grades.Mean);
            }

           [TestMethod]
            public void TestMin()
            {
                 StudentGrades grades = new();
                 grades.Marks = Stats; 
                 grades.CalculateMinMax();
                 expectedOutput = 10;
    
                 Assert.AreEqual(expectedOutput, grades.Minimum);
            }

            [TestMethod]
            public void TestMax()
            {
                StudentGrades grades = new();
                grades.Marks = Stats;

            grades.CalculateMinMax();
                expectedOutput = 100;
 
                Assert.AreEqual(expectedOutput, grades.Maximum);
            }
            
            [TestMethod]

            public void TestGradeProfile()
            {
                grades.Marks = Stats;
                bool expectedProfile = false;

                grades.CalculateGradeProfileUnitTest();

                 expectedProfile = ((grades.GradeProfile[0] == 3) &&
                                   (grades.GradeProfile[1] == 1) &&
                                   (grades.GradeProfile[2] == 1) &&
                                   (grades.GradeProfile[3] == 1) &&
                                   (grades.GradeProfile[4] == 4));

               Assert.IsTrue(expectedProfile);
            }



    }
}
 