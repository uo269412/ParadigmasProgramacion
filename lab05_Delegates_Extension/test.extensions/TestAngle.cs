using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.Laboratory.Functional.Lab05;
using delegates;
namespace test.extensions
{
    [TestClass]
    public class TestAngle
    {
        [TestMethod]
        public void TestFind()
        {
            Angle found;
            Angle[] angles = Factory.CreateAngles();

            found = angles.Find(a => a.Quadrant == 1);
            Assert.IsTrue(found.Degrees < 90);

            found = angles.Find(a => a.Quadrant == 2);
            Assert.IsTrue(found.Degrees > 90 && found.Degrees < 180);

            found = angles.Find(a => a.Quadrant == 3);
            Assert.IsTrue(found.Degrees > 180 && found.Degrees < 270);

            found = angles.Find(a => a.Quadrant == 4);
            Assert.IsTrue(found.Degrees > 270);


        }

        [TestMethod]
        public void TestFilter()
        {
            Angle[] angles = Factory.CreateAngles();
            var filteredAngles = angles.Filter(a => a.Degrees < 180 );
            foreach (Angle element in filteredAngles)
            {
                Assert.IsTrue(element.Quadrant == 1 || element.Quadrant == 2);
            }
            filteredAngles = angles.Filter(a => a.Degrees > 180);
            foreach (Angle element in filteredAngles)
            {
                Assert.IsTrue(element.Quadrant == 3 || element.Quadrant == 4);
            }
        }

        [TestMethod]
        public void TestReduce()
        {
            Angle[] angles = Factory.CreateAngles();

            var reduced = angles.Reduce<Angle, int>(0, (a, count) => count + (a != null ? 1 : 0));
            Assert.AreEqual(reduced, angles.Length);
        }
    }
}
