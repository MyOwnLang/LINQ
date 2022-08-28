using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectionOperators
{
    class Employee
	{
		public int EmployeeID { get; set; }
		public string Name { get; set; }
		public int Salary { get; set; }
	}
    class Program
    {
        static void Main(string[] args)
        {

            /*Remember that if you want select all columns or single column then we dont use anonmyous type.
             We should use anonymous type only if we want more than one column. IMP - inside anonymous, it should be assigned to some variable
            or it should directly come from classobject.member*/

            #region Retrieves just the EmployeeID property of all employees
            /*
            DataTable dt = GetAllEmployees();
            EnumerableRowCollection<string> result = dt.AsEnumerable().Select(emp => emp.Field<string>("FirstName"));

            foreach (var name in result)
            {
                Console.WriteLine(name);
            }
            */
            #endregion

            #region Projects FirstName & Gender properties of all employees into anonymous type.
            /*
            DataTable dt = GetAllEmployees();
            var result = dt.AsEnumerable().Select(emp => new 
                        {
                            FirstName = emp.Field<string>("FirstName"),
                            Gender = emp.Field<string>("Gender")
                        });

            foreach (var v in result)
            {
                Console.WriteLine(v.FirstName + " - " + v.Gender);
            }
            */
            #endregion

            #region Computes FullName and MonthlySalay of all employees and projects these 2 new computed properties into anonymous type.
            /*
            DataTable dt = GetAllEmployees();
            var result = dt.AsEnumerable().Select(emp => new 
                        {
                            Fullname = emp.Field<string>("FirstName") + emp.Field<string>("LastName"),
                            MonthlySalay = emp.Field<int>("AnnualSalary") / 12
                        });

            foreach (var v in result)
            {
                Console.WriteLine(v.Fullname + " - " + v.MonthlySalay);
            }
            */
            #endregion

            #region  Give 10% bonus to all employees whose annual salary is greater than 50000 and project all such employee's FirstName, AnnualSalay and Bonus into anonymous type.
            /*
            DataTable dt = GetAllEmployees();
            var result = dt.AsEnumerable().Where(emp => emp.Field<int>("AnnualSalary") > 5000).Select(emp => new 
                        {
                            Fullname = emp.Field<string>("FirstName") + emp.Field<string>("LastName"),
                            AnnualSalary = emp.Field<int>("AnnualSalary") * .1
                        });

            foreach (var v in result)
            {
                Console.WriteLine(v.Fullname + " - " + v.AnnualSalary);
            }

       

            DataTable dt = GetAllEmployees();
            var result = from emp in dt.AsEnumerable()
                         where emp.Field<int>("AnnualSalary") > 5000
                         select new
                         {
                             Fullname = emp.Field<string>("FirstName") + emp.Field<string>("LastName"),
                             AnnualSalary = emp.Field<int>("AnnualSalary") * .1
                         };
            foreach (var v in result)
            {
                Console.WriteLine(v.Fullname + " - " + v.AnnualSalary);
            }
                 */
            #endregion

            #region inside anonymous, it should be assigned to some variable or it should directly come from classobject.member
            /*
            List<Employee> employees = new List<Employee>
			{
				new Employee { EmployeeID = 1, Name = "Suresh",Salary=8000},
				new Employee { EmployeeID = 2, Name = "Kiran", Salary=12000},
				new Employee { EmployeeID = 3, Name = "Nitesh", Salary = 15000 }
			};

            var result = employees.Where(emp => emp.Salary > 12000).
                                   Select(emp => new
                                   {
                                       emp.EmployeeID, //inside anonymous, it should be assigned to some variable or it should directly come from classobject.member
                                       monthysalary = emp.Salary
                                   });

			foreach (var item in result)
			{
				Console.WriteLine($"The list is {item.EmployeeID} {item.monthysalary}");
			}*/
            #endregion


            #region inside anonymous, using assigned to some variable
            /*
            DataTable dt = GetAllEmployees();
			//var result = dt.AsEnumerable().Where(emp => emp.Field<int>("AnnualSalary") > 45000).
			//							   Select(emp => emp.Field<string>("FirstName")); //this is simple access


			var result = dt.AsEnumerable().Where(emp => emp.Field<int>("AnnualSalary") > 45000).
													Select(emp => new
													{
														name = emp.Field<string>("FirstName"), //inside anonymous, here we using assigned to some variable
														gender = emp.Field<string>("Gender")
													});

			foreach (var v in result)
			{
				Console.WriteLine($"The employeename is {v}");
			}
            */
            #endregion
            Console.ReadLine();
        }

        public static DataTable GetAllEmployees()
        {
            DataTable employee = new DataTable("Employee");
            employee.Columns.Add("EmployeeID", typeof(int));
            employee.Columns.Add("FirstName", typeof(string));
            employee.Columns.Add("LastName", typeof(string));
            employee.Columns.Add("Gender", typeof(string));
            employee.Columns.Add("AnnualSalary", typeof(int));

            employee.Rows.Add(101, "Tom", "Daely", "Male", 600);
            employee.Rows.Add(102, "Mike", "Mist", "Male", 72000);
            employee.Rows.Add(103, "Mary", "Lambeth", "Female", 48000);
            employee.Rows.Add(104, "Pam", "Penny", "Female", 84000);
            employee.Rows.Add(105, "Austin", "Margret", "Male", 90000);

            return employee;

        }
    }
}
