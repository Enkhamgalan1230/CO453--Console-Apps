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

                expectedOutput = 0.0006213727366498068;

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

                expectedOutput = 3.281;

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
            [TestMethod]
            public void TestInchesToYard()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "inches";
                converter.toUnit = "yard";
                converter.fromDis = 1;

                converter.ConvertDis();

                expectedOutput = 0.027777777777777776;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod]
            public void TestYardToMiles()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "yard";
                converter.toUnit = "miles";
                converter.fromDis = 10;

                converter.ConvertDis();

                expectedOutput = 0.005681818181818182;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod] 
            public void TestFeetToCentimeters()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "feet";
                converter.toUnit = "centimeters";
                converter.fromDis = 10;

                converter.ConvertDis();

                expectedOutput = 304.8;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod] 
            public void TestCentimetersToInches()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "centimeters";
                converter.toUnit = "inches";
                converter.fromDis = 10;

                converter.ConvertDis();

                expectedOutput = 3.937007874015748;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }
            [TestMethod] 
            public void TestInchesToKilometers()
            {
                DistanceConverter converter = new DistanceConverter();
                converter.fromUnit = "inches";
                converter.toUnit = "kilometers";
                converter.fromDis = 10;

                converter.ConvertDis();

                expectedOutput = 0.000254000508001016;

                Assert.AreEqual(expectedOutput, converter.toDis);
            }


            




            
        
    }
}