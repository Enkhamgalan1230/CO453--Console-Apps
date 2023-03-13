using ConsoleAppProject.App03;

namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
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

        }
    }
 