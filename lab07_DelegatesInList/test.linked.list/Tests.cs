using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.Laboratory.Functional.Lab05;
using System.Linq;

namespace linked.list
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddTest()
        {
            List<string> listStr = new List<string>();
            listStr.Add("A");
            Assert.AreEqual("A", listStr.GetElement(0));
            Assert.AreEqual(1, listStr.Size);
            listStr.Add("B");
            Assert.AreEqual("B", listStr.GetElement(1));
            Assert.AreEqual(2, listStr.Size);
            listStr.Add("C");
            Assert.AreEqual("C", listStr.GetElement(2));
            Assert.AreEqual(3, listStr.Size);

            List<int> listInt = new List<int>();
            listInt.Add(4);
            Assert.AreEqual(4, listInt.GetElement(0));
            Assert.AreEqual(1, listInt.Size);
            listInt.Add(5);
            Assert.AreEqual(5, listInt.GetElement(1));
            Assert.AreEqual(2, listInt.Size);
            listInt.Add(6);
            Assert.AreEqual(6, listInt.GetElement(2));
            Assert.AreEqual(3, listInt.Size);

            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            Assert.AreEqual(4.0, listDouble.GetElement(0));
            Assert.AreEqual(1, listDouble.Size);
            listDouble.Add(5.0);
            Assert.AreEqual(5.0, listDouble.GetElement(1));
            Assert.AreEqual(2, listDouble.Size);
            listDouble.Add(6.0);
            Assert.AreEqual(6.0, listDouble.GetElement(2));
            Assert.AreEqual(3, listDouble.Size);
        }

        [TestMethod]
        public void TestRemoveTest()
        {
            //Elimination starting from the start of the list
            List<string> listStr = new List<string>();
            listStr.Add("A");
            listStr.Add("B");
            listStr.Add("C");
            Assert.AreEqual(3, listStr.Size);
            listStr.Remove("A");
            Assert.AreEqual("B", listStr.GetElement(0));
            Assert.AreEqual("C", listStr.GetElement(1));
            Assert.AreEqual(2, listStr.Size);
            listStr.Remove("B");
            Assert.AreEqual("C", listStr.GetElement(0));
            Assert.AreEqual(1, listStr.Size);
            listStr.Remove("C");
            Assert.AreEqual(null, listStr.GetElement(0));
            Assert.AreEqual(0, listStr.Size);

            //Elimination starting from the end of the list
            List<int> listInt = new List<int>();
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            Assert.AreEqual(3, listInt.Size);
            listInt.Remove(6);
            Assert.AreEqual(4, listInt.GetElement(0));
            Assert.AreEqual(5, listInt.GetElement(1));
            Assert.AreEqual(2, listInt.Size);
            listInt.Remove(5);
            Assert.AreEqual(4, listInt.GetElement(0));
            Assert.AreEqual(1, listInt.Size);
            listInt.Remove(4);
            Assert.AreEqual(0, listInt.GetElement(0));
            Assert.AreEqual(0, listInt.Size);

            //Elimination starting from the middle of the list
            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            listDouble.Add(5.0);
            listDouble.Add(6.0);
            Assert.AreEqual(3, listDouble.Size);

            listDouble.Remove(5.0);
            Assert.AreEqual(4.0, listDouble.GetElement(0));
            Assert.AreEqual(6.0, listDouble.GetElement(1));
            Assert.AreEqual(2, listDouble.Size);
            listDouble.Remove(4.0);
            Assert.AreEqual(6.0, listDouble.GetElement(0));
            Assert.AreEqual(1, listDouble.Size);
            listDouble.Remove(6.0);
            Assert.AreEqual(0.0, listDouble.GetElement(0));
            Assert.AreEqual(0, listDouble.Size);
        }

        [TestMethod]
        public void TestGetElement()
        {
            List<string> listStr = new List<string>();
            listStr.Add("A");
            listStr.Add("B");
            listStr.Add("C");
            Assert.AreEqual("A", listStr.GetElement(0));
            Assert.AreEqual("B", listStr.GetElement(1));
            Assert.AreEqual("C", listStr.GetElement(2));

            List<int> listInt = new List<int>();
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            Assert.AreEqual(4, listInt.GetElement(0));
            Assert.AreEqual(5, listInt.GetElement(1));
            Assert.AreEqual(6, listInt.GetElement(2));

            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            listDouble.Add(5.0);
            listDouble.Add(6.0);
            Assert.AreEqual(4.0, listDouble.GetElement(0));
            Assert.AreEqual(5.0, listDouble.GetElement(1));
            Assert.AreEqual(6.0, listDouble.GetElement(2));
        }

        [TestMethod]
        public void TestContains()
        {
            List<string> listStr = new List<string>();
            listStr.Add("A");
            listStr.Add("B");
            listStr.Add("C");
            Assert.AreEqual(true, listStr.Contains("A"));
            Assert.AreEqual(true, listStr.Contains("B"));
            Assert.AreEqual(true, listStr.Contains("C"));
            Assert.AreEqual(false, listStr.Contains("D"));
            Assert.AreEqual(false, listStr.Contains("E"));
            Assert.AreEqual(false, listStr.Contains("F"));

            List<int> listInt = new List<int>();
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            Assert.AreEqual(true, listInt.Contains(4));
            Assert.AreEqual(true, listInt.Contains(5));
            Assert.AreEqual(true, listInt.Contains(6));
            Assert.AreEqual(false, listInt.Contains(7));
            Assert.AreEqual(false, listInt.Contains(8));
            Assert.AreEqual(false, listInt.Contains(9));

            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            listDouble.Add(5.0);
            listDouble.Add(6.0);
            Assert.AreEqual(true, listDouble.Contains(4.0));
            Assert.AreEqual(true, listDouble.Contains(5.0));
            Assert.AreEqual(true, listDouble.Contains(6.0));
            Assert.AreEqual(false, listDouble.Contains(7.0));
            Assert.AreEqual(false, listDouble.Contains(8.0));
            Assert.AreEqual(false, listDouble.Contains(9.0));
        }

        [TestMethod]
        public void TestToString()
        {
            List<string> listStr = new List<string>();
            listStr.Add("A");
            listStr.Add("B");
            listStr.Add("C");
            Assert.AreEqual("Position : 0 Content: A // Position : 1 Content: B // Position : 2 Content: C // ", listStr.ToString());

            List<int> listInt = new List<int>();
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            Assert.AreEqual("Position : 0 Content: 4 // Position : 1 Content: 5 // Position : 2 Content: 6 // ", listInt.ToString());

            List<double> listDouble = new List<double>();
            listDouble.Add(4.0);
            listDouble.Add(5.0);
            listDouble.Add(6.0);
            Assert.AreEqual("Position : 0 Content: 4 // Position : 1 Content: 5 // Position : 2 Content: 6 // ", listDouble.ToString());
        }

        [TestMethod]
        public void TestFind()
        {
            List<Person> people = Factory.CreatePeopleForList();
            Person found;

            found = people.Find(p => p.FirstName == "María");
            Assert.AreEqual(found.FirstName, "María");
            Assert.AreEqual(found.Surname, "Díaz");

            found = people.Find(p => p.FirstName == "Juan");
            Assert.AreEqual(found.FirstName, "Juan");
            Assert.AreEqual(found.Surname, "Pérez");

            found = people.Find(p => p.FirstName == "Luis");
            Assert.AreEqual(found.FirstName, "Luis");
            found = people.Find(p => p.FirstName == "Pepe");
            Assert.AreEqual(found.FirstName, "Pepe");

            found = people.Find(p => p.Surname == "Rodríguez");
            Assert.AreEqual(found.Surname, "Rodríguez");
            found = people.Find(p => p.Surname == "Díaz");
            Assert.AreEqual(found.Surname, "Díaz");

            found = people.Find(p => p.IDNumber == "23476293R");
            Assert.AreEqual(found.IDNumber, "23476293R");
            found = people.Find(p => p.IDNumber == "98673645T");
            Assert.AreEqual(found.IDNumber, "98673645T");
        }

        [TestMethod]
        public void TestFilter()
        {
            List<Person> people = Factory.CreatePeopleForList();
            var filteredPeople = people.Filter(p => p.FirstName.Length > 3);
            foreach (Person element in filteredPeople)
            {
                Assert.IsTrue(element.FirstName.Length > 3);
            }
            filteredPeople = people.Filter(p => p.Surname.Contains("z"));
            foreach (Person element in filteredPeople)
            {
                Assert.IsTrue(element.Surname.Contains("z"));
            }
            filteredPeople = people.Filter(p => !p.IDNumber.Contains("1"));
            foreach (Person element in filteredPeople)
            {
                Assert.IsFalse(element.IDNumber.Contains("1"));
            }
        }


        [TestMethod]
        public void TestReduce()
        {
            List<Person> people = Factory.CreatePeopleForList();
            var reduced = people.Reduce<string>((p, count) => string.Concat(count, string.Concat(p.FirstName + ", ")));
            //Assert.AreEqual(reduced, "María, Juan, Pepe, Luis, Carlos, Miguel, Cristina, María, Juan, ");

            var reduced2 = people.Reduce<int>((p, count) => count + (p != null ? 1 : 0));
            Assert.AreEqual(reduced2, people.Size);
        }

        [TestMethod]
        public void TestMap()
        {
            List<Person> people = Factory.CreatePeopleForList();
            var mapped = people.Map<string>(p => p.FirstName);
            Assert.AreEqual(mapped.Last(), people.GetElement(people.Size - 1).FirstName);
            var mapped2 = people.Map<string>((p => p.Surname));
            Assert.AreEqual(mapped2.Last(), people.GetElement(people.Size - 1).Surname);
        }

        public class TestAngle
        {
            [TestMethod]
            public void TestFind()
            {
                Angle found;
                List<Angle> angles = Factory.CreateAnglesForList();

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
                List<Angle> angles = Factory.CreateAnglesForList();
                var filteredAngles = angles.Filter(a => a.Degrees < 180);
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
                List<Angle> angles = Factory.CreateAnglesForList();

                var reduced = angles.Reduce<int>(0, (a, count) => count + (a != null ? 1 : 0));
                Assert.AreEqual(reduced, angles.Size);
            }

            [TestMethod]
            public void TestMap()
            {
                List<Angle> angles = Factory.CreateAnglesForList();
                var mapped = angles.Map<int>(p => p.Quadrant);
                Assert.AreEqual(mapped.Last(), angles.GetElement(angles.Size - 1).Quadrant);
                var mapped2 = angles.Map<int>((p => p.Quadrant));
                Assert.AreEqual(mapped2.Last(), angles.GetElement(angles.Size - 1).Quadrant);
            }


            [TestMethod]
            public void TestInvert()
            {
                List<string> list = new List<string>();
                list.Add("A");
                list.Add("B");
                list.Add("C");
                list.Add("D");
                list.Add("E");
                list.Add("F");
                list.Add("G");
                list.Add("H");
                list.Add("I");
                list.Invert();
                Assert.AreEqual(list.GetElement(0), "I");
                Assert.AreEqual(list.GetElement(1), "H");
                Assert.AreEqual(list.GetElement(2), "G");
                Assert.AreEqual(list.GetElement(3), "F");
                Assert.AreEqual(list.GetElement(4), "E");
                Assert.AreEqual(list.GetElement(5), "D");
                Assert.AreEqual(list.GetElement(6), "C");
                Assert.AreEqual(list.GetElement(7), "B");
                Assert.AreEqual(list.GetElement(8), "A");
            }

            [TestMethod]
            public void TestForEach()
            {
                List<int> list = new List<int>();
                list.Add(0);
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.Add(4);
                list.Add(5);
                list.Add(6);
                list.ForEach(e => e++);
                Assert.AreEqual(list.GetElement(0), 1);
                Assert.AreEqual(list.GetElement(1), 2);
                Assert.AreEqual(list.GetElement(2), 3);
                Assert.AreEqual(list.GetElement(3), 4);
                Assert.AreEqual(list.GetElement(4), 5);
                Assert.AreEqual(list.GetElement(5), 6);
                Assert.AreEqual(list.GetElement(6), 7);
            }
        }
    }
}
