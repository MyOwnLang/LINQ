using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ------------------Distinct()----------------------------------------
            /*
            var result = GetEmployees().AsEnumerable().Distinct();
            foreach (var v in result)
            {
                Console.WriteLine(v.Field<int>("ID") + "\t" + v.Field<string>("Name"));
            }
            //Distinct uses equality comparer so it will use object reference to compare instead of values. So we need to use select ananymous method compare the object values

            foreach (var v in GetEmployees().AsEnumerable().Select(row => new { ID = row.Field<int>("ID"), Name = row.Field<string>("Name") }).Distinct())
            {
                Console.WriteLine(v.ID + " " + v.Name);
            }
            */
            #endregion

            #region ------------------Union()----------------------------------------
            //Union combines two collections into one collection while removing the duplicate elements.
            /*var result = GetContractEmployees().AsEnumerable().Select(x => new { EmployeeName = x.Field<string>("Name")})
                .Union(GetPermanentEmployees().AsEnumerable().Select(y => new { EmployeeName = y.Field<string>("Name") }));

            foreach (var item in result)
            {
                Console.WriteLine(item.EmployeeName);
            }
            */
            #endregion

            #region ------------------Intersect()----------------------------------------
            //Intersect returns the common elements between the 2 collections.
            /* var result = GetContractEmployees().AsEnumerable().Select(x => new { EmployeeName = x.Field<string>("Name")})
                 .Intersect(GetPermanentEmployees().AsEnumerable().Select(y => new { EmployeeName = y.Field<string>("Name") }));

             foreach (var item in result)
             {
                 Console.WriteLine(item.EmployeeName);
             }
             */
            #endregion

            #region ------------------Except()----------------------------------------
            //Except returns the elements that are present in the first collection but not in the second collection.
            var result = GetContractEmployees().AsEnumerable().Select(x => new { EmployeeName = x.Field<string>("Name") })
                .Except(GetPermanentEmployees().AsEnumerable().Select(y => new { EmployeeName = y.Field<string>("Name") }));

            foreach (var item in result)
            {
                Console.WriteLine(item.EmployeeName);
            }

            #endregion
            Console.ReadLine();
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

        private static DataTable GetPermanentEmployees()
        {
            DataTable employee = new DataTable("Employee");
            employee.Columns.Add("ID", typeof(int));
            employee.Columns.Add("Name", typeof(string));
            employee.Columns.Add("DepartmentID", typeof(int));

            employee.Rows.Add(1, "Mark", 1);
            employee.Rows.Add(2, "Steve", 2);
            employee.Rows.Add(3, "Ben", 1);
            employee.Rows.Add(4, "Philip", 1);
            employee.Rows.Add(5, "Martin", 2);
            employee.Rows.Add(6, "Verse", 2);
            employee.Rows.Add(7, "Johnny", 1);
            employee.Rows.Add(8, "Pamler", 1);
            employee.Rows.Add(9, "StaceyKin", 2);
            employee.Rows.Add(10, "AndyRaj", 1);

            return employee;
        }
    }
}
