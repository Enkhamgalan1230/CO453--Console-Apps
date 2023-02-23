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
        
    }
}