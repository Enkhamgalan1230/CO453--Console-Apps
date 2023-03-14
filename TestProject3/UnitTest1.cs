using ConsoleAppProject.App03;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        
        int expectedOutput;

        public int[] Marks { get; private set; }

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
                int[] statsMarks = new int[]
                {
                   10,20,30,40,50,60,70,80,90,100
                };
               
                StudentGrades grades = new();

                grades.CalculateMean();

                expectedOutput = 55;

                Assert.AreEqual(expectedOutput, grades.Mean);
            }

           [TestMethod]
            public void TestMin()
            {
                StudentGrades grades = new();

                grades.CalculateMinMax();
                expectedOutput = 10;

            Assert.AreEqual(expectedOutput, grades.Minimum);
            }

            [TestMethod]
            public void TestMax()
            {
               StudentGrades grades = new();

               grades.CalculateMinMax();
               expectedOutput = 100;
 
               Assert.AreEqual(expectedOutput, grades.Maximum);
            }




    }
}
 