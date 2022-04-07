namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
      [Test]
      public void TheElementsCountShouldBe16()
      {
          Database database = new Database();
          for (int i = 0; i < 16; i++)
          {
              database.Add(i);
          }
          Assert.AreEqual(16, database.Count);
      }
      [Test]
      //[TestCase(5)] TODO:ADD ONE MORE TEST FOR ELEMENTS UNDER 16
      [TestCase(16)]
      public void TheElementsCantBeMoreThan16(int n)
      {
          Database database = new Database();
          for (int i = 0; i < n; i++)
          {
              database.Add(i);
          }
          int a = 1;
          Assert.Throws<InvalidOperationException>(() =>
          {
              database.Add(a);
          });
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
      [Test]
      public void TheCollectionShouldRemoveElements()
      {
          Database database = new Database();
     
          database.Add(1);
          database.Add(1);
          database.Add(1);
          database.Remove();
     
          Assert.AreEqual(2, database.Count);
      }
      [Test]
      public void TheFetchMethodShouldReturnTheSameArrray()
      {
          Database database = new Database();
          database.Add(1);
          database.Add(1);
          database.Add(1);
          database.Add(1);
     
          var fetchResult = database.Fetch();
     
          Assert.AreEqual(4, fetchResult.Length);
      }
    }
}
