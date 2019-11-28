using System;
using System.Collections.Generic;

namespace Lab_08_TDD_Collections
{
    class Program
    {
//      Add a class called Lab_08_Array_List_Dictionary
//      Add a method int Lab_08_Array_List_Dictionary_Get_Total(int a, b, c, d, e)
//      Create some code to take in 5 numbers as input
//      Take those numbers, add 5, and put into an Array
//      Iterate over the array, extract the numbers, square the numbers, and add to a List
//      Iterate over the list, subtract 10, add to a Dictionary<int, int>
//      Iterate over dictionary and return sum
//      Return the answer
        static void Main(string[] args)
        {
          //  Lab_08_Array_List_Dictionary lab = new Lab_08_Array_List_Dictionary();

            //Console.WriteLine(lab.Lab_08_Array_List_Dictionary_Get_Total(1, 2, 3, 4, 5));

        }
    }
    public  class Lab_08_Array_List_Dictionary
    {
        public static int Lab_08_Array_List_Dictionary_Get_Total(int a, int b, int c, int d, int e)
        {
            int ID = 0;

            int result = 0;

            Dictionary<int, int> intDict = new Dictionary<int, int>();

            List<int> intList = new List<int>();

            int[] intArray = new int[]
            {
                    a + 5, b + 5, c + 5, d + 5, e +5
            };

            foreach (var num in intArray)
            {
                int newNum = num * num;
                intList.Add(newNum);
            }

            foreach (var num in intList)
            {
                ID++;
                int newNum = num - 10;
                intDict.Add(ID, newNum);
            }

            foreach (KeyValuePair<int, int> num in intDict)
            {
                result += num.Value;
            }

            return result;
        }
    }
}
