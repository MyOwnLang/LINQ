using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateFucntions
{
    class Program
    {
        static void Main(string[] args)
        {
            /* To find the least even number in the array using extension methods
            int[] numbers = {1,2,3,4,5,6,7,8,9,10};
            int result = numbers.Where(n => n % 2 == 0).Min();*/

            /* To find the large even number in the array
           int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
           int result = numbers.Where(n => n % 2 == 0).Max(); */

            /* To find the sum of all even number in the array 
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int result = numbers.Where(n => n % 2 == 0).Sum();*/

            /*To find the average of all even number in the array 
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double result = numbers.Where(n => n % 2 == 0).Average(); */

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int result = numbers.Where(n => n % 2 == 0).Count();

            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
