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

            var result = GetContractEmployees().AsEnumerable().Any(row => row.Field<string>("Name").Equals("MARY",StringComparison.OrdinalIgnoreCase));
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
    }
}
