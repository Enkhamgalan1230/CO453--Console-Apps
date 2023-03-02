using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;
namespace ConsoleAppUnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        DistanceConverter converter = new DistanceConverter();
        double expectedOutput;

            [TestMethod]
            public void TestFeetToMiles()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "feet";
                converter.toUnit = "miles";
                converter.fromDis = 10560;

                converter.ConvertDis();

                expectedOutput = 2.0;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod]
            public void TestMilesToFeet()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "miles";
                converter.toUnit = "feet";
                converter.fromDis = 2.0;

                converter.ConvertDis();

                expectedOutput = 10560;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod]    
            public void MilesToMeters()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "miles";
                converter.toUnit = "meters";
                converter.fromDis = 1;

                converter.ConvertDis();

                expectedOutput = 1609.34;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod]
            public void TestMetersToMiles()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "meters";
                converter.toUnit = "miles";
                converter.fromDis = 1;

                converter.ConvertDis();

                expectedOutput = 0.0001893939393939394;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod]
            public void TestMetersToFeet()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "meters";
                converter.toUnit = "feet";
                converter.fromDis = 1;

                converter.ConvertDis();

                expectedOutput = 0.30478512648582745;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod]
            public void TestFeetToMeters()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "feet";
                converter.toUnit = "meters";
                converter.fromDis = 10;

                converter.ConvertDis();

                expectedOutput = 3.047851264858275;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }




            
        
    }
}