using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConversionOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ToList()
            //------------------ToList()----------------------------------------
            /*
            DataTable employee = CreateDataTable();
            List<DataRow> result = employee.AsEnumerable().Where(row => row.Field<string>("FirstName").StartsWith("H")).ToList();
            Console.WriteLine($"List of all employees who name starts with character H");
            Console.WriteLine($"------------------------------------------------------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Field<string>("FirstName")}");
            }

            DataTable employee = CreateDataTable();
            List<DataRow> result = (from row in employee.AsEnumerable()
                                    where row.Field<string>("FirstName").StartsWith("H")
                                    select row).ToList();

            Console.WriteLine($"List of all employees who name starts with character H");
            Console.WriteLine($"------------------------------------------------------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Field<string>("FirstName")}");
            }*/
            #endregion

            #region ToArray()
            //------------------ToArray()----------------------------------------
            /*
            DataTable employee = CreateDataTable();
            DataRow[] result = employee.AsEnumerable().Where(row => row.Field<string>("FirstName").StartsWith("H")).ToArray();
            Console.WriteLine($"List of all employees who name starts with character H");
            Console.WriteLine($"------------------------------------------------------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Field<string>("FirstName")}");
            }

            DataTable employee = CreateDataTable();
            DataRow[] result = (from row in employee.AsEnumerable()
                                where row.Field<string>("FirstName").StartsWith("H")
                                select row).ToArray();

            Console.WriteLine($"List of all employees who name starts with character H");
            Console.WriteLine($"------------------------------------------------------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Field<string>("FirstName")}");
            }*/
            #endregion

            #region ToDictionary
            //------------------ToDictionary()----------------------------------------does not allow dupicate keys

            // DataTable employee = CreateDataTable();
            //Dictionary<int, DataRow> result = employee.AsEnumerable().ToDictionary(row => row.Field<int>("EmployeeID"),row=> row);
            //    //.ToDictionary(row => row.Field<string>("FirstName").StartsWith("H")); //because dictionary does not contain parameterless constructor. 
            ////Inside this you must use  two lambda such that there should unique "key" with first lambda expression and second lamba expression as element of that key. Here we cannot use where lambda expression becuase it gives bool as key
            //Console.WriteLine($"List of all employees who name starts with character H");
            //Console.WriteLine($"------------------------------------------------------");
            //foreach (var item in result)
            //{

            //    Console.WriteLine($"{item.Value.Field<string>("FirstName")}");
            //}

            // IDictionary<int, string> result = employee.AsEnumerable().ToDictionary(row => row.Field<int>("EmployeeID"), row => row.Field<string>("FirstName"));
            //.ToDictionary(row => row.Field<string>("FirstName").StartsWith("H")); //because dictionary does not contain parameterless constructor. 
            //Inside this you must use  two lambda such that there should unique "key" with first lambda expression and second lamba expression as element of that key. Here we cannot use where lambda expression becuase it gives bool as key
            //Console.WriteLine($"List of all employees who name starts with character H");
            //Console.WriteLine($"------------------------------------------------------");
            //foreach (var item in result)
            //{

            //    Console.WriteLine($"{item.Value}");
            //}

            #endregion

            #region ToLookUp()
            //------------------ToLookUp()----------------------------------------does allow dupicate keys----it mostly used for grouping

            /*
            DataTable employee = CreateDataTable();
            var result = employee.AsEnumerable().ToLookup(row => row.Field<string>("Gender"), row => row);
            //.ToDictionary(row => row.Field<string>("FirstName").StartsWith("H")); //because dictionary does not contain parameterless constructor. 
            //Inside this you must use  two lambda such that there should unique "key" with first lambda expression and second lamba expression as element of that key. Here we cannot use where lambda expression becuase it gives bool as key
            Console.WriteLine($"List of all employees who name starts with character H");
            Console.WriteLine($"------------------------------------------------------");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine("============");
                var rr = result[item.Key];
                foreach (var data in result[item.Key])
                {
                    Console.WriteLine($"{data.Field<string>("FirstName")}");
                }
                Console.WriteLine();
            }

            // IDictionary<int, string> result = employee.AsEnumerable().ToDictionary(row => row.Field<int>("EmployeeID"), row => row.Field<string>("FirstName"));
            //.ToDictionary(row => row.Field<string>("FirstName").StartsWith("H")); //because dictionary does not contain parameterless constructor. 
            //Inside this you must use  two lambda such that there should unique "key" with first lambda expression and second lamba expression as element of that key. Here we cannot use where lambda expression becuase it gives bool as key
            //Console.WriteLine($"List of all employees who name starts with character H");
            //Console.WriteLine($"------------------------------------------------------");
            //foreach (var item in result)
            //{

            //    Console.WriteLine($"{item.Value}");
            //}
            */
            #endregion

            #region cast()

            //------------------cast()----------------------------------------It tries to convert all values when it cannot convert then exception will be thrown
            /*
            DataTable employee = CreateDataTable();
            var result = employee.AsEnumerable().Select(row => row.Field<object>("EmployeeID")).Cast<int>();
                
            foreach (var item in result)
            {
                Console.WriteLine(item + "\t" + item.GetType());
            }

            */
            #endregion

            #region OfType()
            //------------------OfType()----------------------------------------It tries to convert all values when it cannot convert then it will ignore those values. Exception will not be thrown

            DataTable employee = CreateDataTable();
            var result = employee.AsEnumerable().Select(row => row.Field<object>("EmployeeID")).OfType<int>();

            foreach (var item in result)
            {
                Console.WriteLine(item + "\t" + item.GetType());
            }

            #endregion

            Console.ReadLine();
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
            employeeData.Rows.Add(102, "Alexa", "Bliss", "Female", new DateTime(1991, 07, 24));
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
