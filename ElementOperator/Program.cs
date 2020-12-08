using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ElementOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ------------------First()----------------------------------------
            /*
            //Example 1: Returns the first element from the sequence [ i.e source carrier]
            DataTable employee = CreateDataTable();
            DataRow result = employee.AsEnumerable().First();
            Console.WriteLine($"First() will return the 1st record from the dataTable");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"{result.Field<string>("FirstName")}");
            Console.ReadLine();

            If the sequence does not contain any elements, then First() method throws an InvalidOperationException.
            Example 2: Throws InvalidOperationException.

            DataTable employee = CreateDataTable();
            DataRow result = employee.AsEnumerable().First();
            Console.WriteLine($"First() will return the 1st record from the dataTable");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"{result.Field<string>("FirstName")}");
            Console.ReadLine();

            /*The second overloaded version is used to find the first element in a sequence based on a condition. 
            If the sequence does not contain any elements or if no element in the sequence satisfies the condition then an InvalidOperationException is thrown.
            //Example 3: Returns the first even number from the sequence

            DataTable employee = CreateDataTable();
            DataRow result = employee.AsEnumerable().First(row => row.Field<int>("EmployeeID") > 104);
            Console.WriteLine($"First() will return the 1st record from the dataTable");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"{result.Field<string>("FirstName")}");
            Console.ReadLine();

            */

            #endregion

            #region------------------FirstorDefault()---------------------------
            /*
            //Example 1: Returns ZERO. No element in the sequence satisfies the condition, so the default value (ZERO) for int is returned.

            DataTable employee = CreateDataTable();
            DataRow result = employee.AsEnumerable().FirstOrDefault(row => row.Field<int>("EmployeeID") > 109);
            Console.WriteLine($"FirstOrDefault() will return the 1st record from the dataTable if found otherwise it will return default datatype of source");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"{result.Field<string>("FirstName")}");
            Console.ReadLine();
           Last: Very similar to First, except it returns the last element of the sequence.

           LastOrDefault: Very similar to FirstOrDefault, except it returns the last element of the sequence.
            */

            #endregion

            #region------------------ElementAt()----------------------------------------
            /*
            DataTable employee = CreateDataTable();
            DataRow result = employee.AsEnumerable().ElementAt(1);
            Console.WriteLine($"ElementAt() Returns an element at a specified index. If the sequence is empty or if the provided index value is out of range, then an ArgumentOutOfRangeException is thrown");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"{result.Field<string>("FirstName")}");
            Console.ReadLine();

           //ElementAtOrDefault: Similar to ElementAt except that this method does not throw an exception, if the sequence is empty or if the provided index value is out of range. Instead, a default value of the type that is expected is returned.
            */
            #endregion

            #region------------------Single()-------------------------------------
            /*
            DataTable employee = CreateDataTable();
            DataRow result = employee.AsEnumerable().Single(row => row.Field<int>("EmployeeID") == 101);
            Console.WriteLine($"FirstOrDefault() will return Returns the only element (1) of the sequence. if there is more than one element found otherwise it will throws an exception if the sequence is empty or has more than one element.");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"{result.Field<string>("FirstName")}");
            Console.ReadLine();

                //SingleOrDefault: Very similar to Single(), except this method does not throw an exception when the sequence is empty or when no element in the sequence satisfies the given condition. 
                //Just like Single(), this method will still throw an exception, if more than one element in the sequence satisfies the given condition.
            */
            #endregion

            #region------------------DefaultIfEmpty()----------------------------------------
            /*
            DataTable employee = CreateDataTable();
            IEnumerable<DataRow> result = employee.AsEnumerable().DefaultIfEmpty();
            Console.WriteLine($"DefaultIfEmpty()  If the sequence on which this method is called is not empty, then the values of the original sequence are returned.");
            Console.WriteLine($"------------------------------------------------------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Field<string>("FirstName")}");
            }
            //The other overloaded version with a parameter allows us to specify a default value.If this method is called on a sequence that is not empty, then the values of the original sequence are returned.If the sequence is empty, then this method returns a sequence with the specified defualt value.
            Example 14 : Since the sequence is empty, a sequence containing the specified default value(10) is returned.
            int[] numbers = { };
            IEnumerable<int> result = numbers.DefaultIfEmpty(10);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }

        Output:
            10
          Console.ReadLine();*/
            #endregion
        }

        private static DataTable CreateDataTable()
        {
            DataTable employeeData = new DataTable("Employee");
            employeeData.Columns.Add("EmployeeID", typeof(object));
            employeeData.Columns.Add("FirstName", typeof(string));
            employeeData.Columns.Add("LastName", typeof(string));
            employeeData.Columns.Add("Gender", typeof(string));
            employeeData.Columns.Add("DOB", typeof(DateTime));


            employeeData.Rows.Add(101, "Tom", "Daley", "Male", new DateTime(1988, 12, 12));
            employeeData.Rows.Add(101, "Alexa", "Bliss", "Female", new DateTime(1991, 07, 24));
            employeeData.Rows.Add(103, "Mark", "Butcher", "Male", new DateTime(1988, 08, 4));
            employeeData.Rows.Add(104, "Henry", "Kilsmen", "Male", new DateTime(1988, 06, 23));
            employeeData.Rows.Add(105, "Hanna-esi", "grimse", "Male", new DateTime(1978, 02, 12));
            employeeData.Rows.Add(100, "Su", "Daley", "Male", new DateTime(1988, 12, 12));
            employeeData.Rows.Add(106, "Hanna-Last", "castle", "Female", new DateTime(1990, 02, 2));
            employeeData.Rows.Add(107, "Hanna-summer", "castle", "Female", new DateTime(1996, 02, 2));

            return employeeData;

        }
    }
}
