using System;
using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;

namespace NUNIT_Tests
{
    [TestFixture]
    public class Tests
    {
        Lab_08_Array_List_Dictionary lab = new Lab_08_Array_List_Dictionary();

        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Test1()
        //{
        //    var expected = 280;
        //    var actual = lab.Lab_08_Array_List_Dictionary_Get_Total(1, 2, 3, 4, 5);
        //    Assert.AreEqual(expected, actual);
        //}
        //[Test]
        //public void Test2()
        //{
        //    var expected = 280;
        //    var actual = lab.Lab_08_Array_List_Dictionary_Get_Total(5, 5, 5, 5, 5);
        //    Assert.AreNotEqual(expected, actual);
        //}
        [TestCase(1, 2, 3, 4, 5, 280)]
        [TestCase(20, 21, 22, 23, 24, 3605)]
        [TestCase(30, 31, 32, 33, 34, 6805)]
        [TestCase(40, 41, 42, 43, 44, 11005)]
        public void ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e, int expected)
        {
            // Call method in other project
            int act = Lab_08_Array_List_Dictionary.Lab_08_Array_List_Dictionary_Get_Total(a, b, c, d, e);
            // Get answer
            //See if answer is correct or not
            Assert.AreEqual(expected, act);
        }

        [TestCase(3,7,8)]
        public void RabbitGrowthTests(int totalYears,int expectedRabbitAge,int expectedRabbitCount)
        {
            // Arrange

            // Act
            // Tuple (int NAME,int NAME)
            (int actualCumulativeAge,int actualRabbitCount) = Rabbit_Collection.MultiplyRabbits(totalYears);

            // Assert
            Assert.AreEqual(expectedRabbitAge,actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
        
        [TestCase(3, 3, 1)]
        [TestCase(4, 4, 2)]
        [TestCase(5, 6, 3)]
        [TestCase(6, 9, 4)]
        public void MultiplyRabbitAfterAgeReachedThreeTest(int totalYears, int expectedRabbitAge, int expectedRabbitCount)
        {
            // Arrange
            // Create Instance in here if not static

            // Act
            // Tuple (int NAME, int NAME)
            (int actualRabbitAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbitsAfterAgeThreeReached(totalYears);

            // Assert
            Assert.AreEqual(expectedRabbitAge, actualRabbitAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
    }
}
