using System;
using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;
using Lab_17_Nothwind_Tests;
using Lab_14_LINQ;
using Lab_20_Northwind_Products;
using Lab_28_Fibonacci;
using Simpson_HW;

namespace NUNIT_Tests
{
    [TestFixture]
    public class Tests
    {
        #region ArrayTests

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

        #endregion

        #region RabbitTests

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

        #endregion

        #region TestNumberOfNorthwindCustomers

        [TestCase(null, 91)]
        [TestCase("London", 6)]

        public void TestNumberOfNorthwindCustomers(string city, int expected)
        {
          
            // Assert
            Assert.AreEqual(expected, Lab_14_LINQ.Program.GetCustomers(city));

        }


        #endregion

        #region TestNumberOfProducts
        [TestCase(3, "P")]
        [TestCase(3, "P")]
        public void TestNumberOfProductsStartingWithP(int expected, string product)
        {
            // Arrange (Instance)


            // Act (Method)


            // Assert
            Assert.AreEqual(expected, Lab_20_Northwind_Products.Program.GetProducts(product));

        }

        #endregion

        #region FibonacciTests

        [TestCase(5,5)]
        [TestCase(1,0)]

        public void TestFibonacciNthNumber(int expected, int nth)
        {
            // Arrange (Instance)

            // Act (Method)


            // Assert
            Assert.AreEqual(expected, Lab_28_Fibonacci.Fibonacci.ReturnFibonacciNthItemInSequence(nth));
        }

        #endregion

        #region Simpsons
        [TestCase(6, 0, 6, 72)]
        [TestCase(3, 0, 6, 145)]
        [TestCase(12, 0, 12, 576)]
        [TestCase(6, 0, 12, 1153)]
        public void TestSimposon(int n, int min, int max, int actual)
        {
            Simpson simpson = new Simpson();

            double expected = simpson.areaApprox(n, min, max);

            Assert.AreEqual(expected, actual);
        }


        #endregion 
    }
}
