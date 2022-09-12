using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Qunatifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            //all,any,contains
            /*Quantifiers are used to get boolean results*/
            #region------------------All()-------------------------------------
            /*If all the elements match the given conditon the All() method will return true otherwise it will return false
            DataTable employee = CreateDataTable();
            var resultAll = employee.AsEnumerable().Any(row => row.Field<int>("EmployeeID") == 101);
            Console.WriteLine($"{resultAll}");
            Console.ReadLine();*/
            #endregion

            #region------------------Any()-------------------------------------
            /*If any one of the elements match the given conditon the Any() method will return true otherwise it will return false*/
            // var result = GetContractEmployees().AsEnumerable().Any(row => row.Field<string>("Name").Equals("MARY",StringComparison.OrdinalIgnoreCase));
            #endregion

            #region------------------Contains()-------------------------------------
            //I have not used lambda expression inside contains 
            //becuase contains() does not contain any FUNC delegate as a parameter.
            //Contains() --> it will loop through each record and test for existance of the passed row values.
            DataTable employee = CreateDataTable();
            DataRow dataRowNeedsTobeChecked = employee.NewRow();
            dataRowNeedsTobeChecked.SetField("EmployeeID", 107);
            dataRowNeedsTobeChecked.SetField("FirstName", "Hanna-summer");
            dataRowNeedsTobeChecked.SetField("LastName", "castle");
            dataRowNeedsTobeChecked.SetField("Gender", "Female");
            dataRowNeedsTobeChecked.SetField("DOB", new DateTime(1996, 02, 2));
            var result = employee.AsEnumerable().Contains(dataRowNeedsTobeChecked, new EmployeeRowComparer());

            #endregion
        }

        private static DataTable GetContractEmployees()
        {
            DataTable employee = new DataTable("Employee");
            employee.Columns.Add("ID", typeof(int));
            employee.Columns.Add("Name", typeof(string));
            employee.Columns.Add("DepartmentID", typeof(int));

            employee.Rows.Add(1, "Mark", 1);
            employee.Rows.Add(2, "MarTINk", 2);
            employee.Rows.Add(3, "Ben", 1);
            employee.Rows.Add(4, "Philip", 1);
            employee.Rows.Add(5, "Mary", 2);
            employee.Rows.Add(6, "Valarie", 2);
            employee.Rows.Add(7, "John", 1);
            employee.Rows.Add(8, "Pam", 1);
            employee.Rows.Add(9, "Stacey", 2);
            employee.Rows.Add(10, "Andy", 1);

            return employee;
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
