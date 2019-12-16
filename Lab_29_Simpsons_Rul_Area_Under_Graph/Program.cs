using System;
using System.Collections.Generic;
using System.Linq;


namespace Simpson_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            Simpson simpson = new Simpson();
            Console.WriteLine(simpson.areaApprox(6, 0, 12));
        }
    }

    /* Homework
 * Graph of y = X*X (Can hard code in)
 * Points 0,1,2,3,4,5,6 (Values of X (Also N))
 * Value of Y : 0,1,4,9,16,25,36
 * Goal approximate Area under graph
 * Simpson's Rule:
 * Area = ((MAX X - MIN X)/ 3N) * [Y(0th Item) + Y(Last item) + 4(odd index items ie 1,3,5) + 2(even indexed items ie 2,4)]
 *  
 *  public double GetAreaUnderGraphUsingSimposonsRule(int n, int min, int max, int difference)
 *  {n = 6, min = 0, max = 6,difference = (max-min/n)}
 *  Area = 60 (if n is 6)
 */
    public class Simpson
    {
        public double areaApprox(int n, int min, int max)
        {

            double deltax = (max - min) / n;
            int[] x = new int[max];
            int[] y = new int[max];
            int oddIndex = 0;
            int evenIndex = 0;
            int count = 0;
            for (int i = 0; i < max; i++)
            {
                x[i] = (i + 1);
                y[i] = ((i + 1) * (i + 1));
            }
            foreach (int num in y)
            {
                if (count == (max - 1))
                {

                }
                else if (x[count] % 2 == 0)
                {
                    evenIndex += num;
                    count++;
                }
                else
                {
                    oddIndex += num;
                    count++;
                }
            }

            double area = (deltax / 3) * (y[min] + y[max - 1] + (oddIndex * 4) + (evenIndex * 2));
            return Math.Round(area);
        }

    }
}