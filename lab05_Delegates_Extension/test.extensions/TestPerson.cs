using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.Laboratory.Functional.Lab05;
using delegates;
namespace test.extensions
{
    [TestClass]
    public class TestPerson
    {
        [TestMethod]
        public void TestFind()
        {
            Person found;
            Person[] people = Factory.CreatePeople();

            found = people.Find(p => p.FirstName == "María");
            Assert.AreEqual(found.FirstName, "María");
            Assert.AreEqual(found.Surname, "Díaz");
            Assert.AreEqual(found.IDNumber, "9876384A");

            found = people.Find(p => p.FirstName == "Juan");
            Assert.AreEqual(found.FirstName, "Juan");
            Assert.AreEqual(found.Surname, "Pérez");
            Assert.AreEqual(found.IDNumber, "103478387F");

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
            Person[] people = Factory.CreatePeople();
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
            Person[] people = Factory.CreatePeople();
            var reduced = people.Reduce<Person, string>("", (p, count) => string.Concat(count, string.Concat(p.FirstName, ", ")));
            Assert.AreEqual(reduced, "María, Juan, Pepe, Luis, Carlos, Miguel, Cristina, María, Juan, ");

            var reduced2 = people.Reduce<Person, int>(0, (p, count) => count + (p != null ? 1 : 0));
            Assert.AreEqual(reduced2, people.Length);
        }
    }
}
