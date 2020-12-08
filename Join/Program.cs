using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Join
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ------------------GroupJoin----------------------------------------

            //This is similar to outer join.It can be written in extension method and sql server syntax. Prefer sql server syntax as it is esay to understand and write
            /*
            var result = from d in GetDepatment().AsEnumerable()
                         join e in GetEmployees().AsEnumerable()
                         on d.Field<int>("ID") equals e.Field<int>("DepartmentID") into eGroup
                         select new
                         {
                             Employees = eGroup,
                             Department = d
                         };

            foreach (var department in result)
            {
                Console.WriteLine(department.Department.Field<string>("Name"));
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(" " + employee.Field<string>("Name"));
                }
                Console.WriteLine();
            }
            */
            #endregion

            #region ------------------InnerJoin----------------------------------------
            /*
            //This is similar to inner join.It can be written in extension method and sql server syntax. Prefer sql server syntax as it is esay to understand and write
            
            var result = from d in GetDepatment().AsEnumerable()
                         join e in GetEmployees().AsEnumerable()
                         on d.Field<int>("ID") equals e.Field<int>("DepartmentID")
                         select new
                         {
                             Employees = e.Field<string>("Name"),
                             Department = d.Field<string>("Name")
                         };

            foreach (var item in result)
            {
                Console.WriteLine(item.Department + " " + item.Employees);
                Console.WriteLine();
            }
            */
            #endregion

            #region------------------LeftouterJoin----------------------------------------
            /*
            //This is similar to inner join.It can be written in extension method and sql server syntax. Prefer sql server syntax as it is esay to understand and write

            var result = from e in GetEmployees().AsEnumerable()
                         join d in GetDepartment().AsEnumerable()
                         on e.Field<int?>("DepartmentID") equals d.Field<int>("ID")  into eGroup
                         from x in eGroup.DefaultIfEmpty()
                         select new
                         {
                             Employees = e.Field<string>("Name"),
                             Department = x == null ? "No Department" : x.Field<string>("Name")
                         };

            foreach (var item in result)
            {
                Console.WriteLine(item.Employees + "--->" + item.Department);
                Console.WriteLine();
            }
            */
            #endregion

            #region------------------Cross Join----------------------------------------

            //This is similar to join.It can be written in extension method and sql server syntax. Prefer sql server syntax as it is esay to understand and write

            var result = from e in GetEmployees().AsEnumerable()
                         from d in GetDepartment().AsEnumerable()
                         select new
                         {
                             Employees = e.Field<string>("Name"),
                             Department = d.Field<string>("Name")
                         };

            Console.WriteLine(result.Count());
            foreach (var item in result)
            {
                Console.WriteLine(item.Employees + "--->" + item.Department);
                Console.WriteLine();
            }

            #endregion
            Console.ReadLine();
        }

        private static DataTable GetEmployees()
        {
            DataTable employee = new DataTable("Employee");
            employee.Columns.Add("ID", typeof(int));
            employee.Columns.Add("Name", typeof(string));
            employee.Columns.Add("DepartmentID", typeof(int));

            employee.Rows.Add(1, "Mark", 1);
            employee.Rows.Add(2, "Steve", 2);
            employee.Rows.Add(3, "Ben", 1);
            employee.Rows.Add(4, "Philip", 1);
            employee.Rows.Add(5, "Mary", 2);
            employee.Rows.Add(6, "Valarie", 2);
            employee.Rows.Add(7, "John", 1);
            employee.Rows.Add(8, "Pam", 1);
            employee.Rows.Add(9, "Stacey", 2);
            employee.Rows.Add(10, "Andy",1);

            return employee;
        }

        private static DataTable GetDepartment()
        {
            DataTable department = new DataTable("Department");
            department.Columns.Add("ID", typeof(int));
            department.Columns.Add("Name", typeof(string));

            department.Rows.Add(1, "IT");
            department.Rows.Add(2, "HR");
            department.Rows.Add(3, "PayRoll");

            return department;
        }
    }
}
