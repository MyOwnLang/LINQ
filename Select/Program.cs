using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = { "apple", "banana", "mango", "orange",
                      "passionfruit", "grape" };

            var query =fruits.Select((fruit, index) => new { index, str = fruit.Substring(0, index) });

            foreach (var obj in query)
            {
                Console.WriteLine("{0}", obj);
            }
        }
    }
}
