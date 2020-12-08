using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ------------------Range()----------------------------------------
            /*var result = Enumerable.Range(1, 10).Where(x => x % 2 == 0);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region ------------------Repeat()----------------------------------------
            /*
            //Repeat operator is used to generate a sequence that contains one repeated value.
            var result = Enumerable.Repeat("Hello", 5);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Empty operator returns an empty sequence of the specified type. For example
Enumerable.Empty<int>() - Returns an empty IEnumerable<int>
Enumerable.Empty<string>() - Returns an empty IEnumerable<string>
            */
            #endregion
            Console.ReadKey();
        }
    }
}
