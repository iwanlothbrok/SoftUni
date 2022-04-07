namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void AddMethodShouldThrowExceptionForAddingSameUsername()
        {
            Person person = new Person(11112222, "Iwan");
            Person person2 = new Person(1, "Iwan");
            Database database = new Database();
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person2);
            });
        }
        [Test]
        public void AddMethodShouldThrowExceptionForAddingSameID()
        {
            Person person = new Person(11112222, "Iwan");
            Person person2 = new Person(11112222, "Petio");
            Database database = new Database();
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person2);
            });
        }
        [Test]
        public void RemoveMethodShouldRemove()
        {
            Person person = new Person(11112222, "Iwan");
            Database database = new Database();
            database.Add(person);

            database.Remove();


            Assert.AreEqual(0, database.Count);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionForRemovingInEmptyCollection()
        {
            Person person = new Person(11112222, "Iwan");
            Database database = new Database();
            database.Add(person);

            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
        [Test]
        public void FindByUsernameShouldThrowExceptionForEmptyCollection()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Iwo");
            });
        }
        [Test]
        public void FindByUsernameShouldThrowExceptionForIncorrectUsername()
        {
            Person person = new Person(11112222, "Iwan");
            Database database = new Database();
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
                {
                    database.FindByUsername("Iwo");
                });
        }
        [Test]
        public void FindByUsernameShouldThrowExceptionForCaseSensetivity()
        {
            Person person = new Person(11112222, "Iwan");
            Database database = new Database();
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("iwo");
            });
        }
        [Test]
        public void FindByUsernameShouldReturnCorrectly()
        {
            Person person = new Person(11112222, "Iwan");
            Database database = new Database();
            database.Add(person);

            Assert.AreEqual(database.FindByUsername("Iwan"), person);
        }
        [Test]
        public void FindByUsernameShouldReturnExceptionForNullUsername()
        {
            Person person = new Person(11112222, "owan");
            Database database = new Database();
            database.Add(person);
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }
        [Test]
        public void FindByIDShouldThrowExceptionForEmptyCollection()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(12);
            });
        }
        [Test]
        public void FindByIDShouldThrowExceptionForIncorrectID()
        {
            Person person = new Person(11112222, "Iwan");
            Database database = new Database();
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(12);
            });
        }
        [Test]
        public void FindByIDShouldThrowExceptionForNegativeID()
        {
            Person person = new Person(123123, "Iwan");
            Database database = new Database();
            database.Add(person);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
               database.FindById(-1);
            });
        }
        [Test]
        public void FindByIDShouldReturnCorretly()
        {
            Person person = new Person(123123, "Iwan");
            Database database = new Database();
            database.Add(person);

            Assert.AreEqual(database.FindById(123123), person);
                 
          
        }
        [Test]
        public void TheCollectionCantBeEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
      
    }
}