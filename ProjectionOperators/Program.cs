using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectionOperators
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 },
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000 },
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000 },
                new Employee {ID = 104, FirstName = "Anurag", LastName = "Mohanty", Salary = 90000 },
                new Employee {ID = 105, FirstName = "Sambit", LastName = "Satapathy", Salary = 100000 },
                new Employee {ID = 106, FirstName = "Sushanta", LastName = "Jena", Salary = 160000 }
            };
            return employees;
        }
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

           // var output = dt.AsEnumerable().Select((datarow) => datarow.Field<string>("FirstName"));
           // var output = dt.AsEnumerable().Select((datarow) => new { name = datarow.Field<string>("FirstName")});

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

            #region getting index positon for employees when the data source is DataTable
            /*
            DataTable dt = GetAllEmployees();
			var result = dt.AsEnumerable().Select((row,index) => new 
                                                  { 
                                                    employeeIndex = index,
                                                    Name = row.Field<string>("FirstName") + row.Field<string>("LastName")
                                                    }); //this is simple access

            foreach (var v in result)
            {
                Console.WriteLine($"The employeeIndex is {v.employeeIndex} and empoyeeName is {v.Name}");
            }
            */
            #endregion

            #region getting index positon for employees when the data source is collection
            /*
            var result = Employee.GetEmployees().AsEnumerable().Select((emp, index) => new
            {
                employeeIndex = index,
                Name = emp.FirstName + emp.LastName
            }); //this is simple access

            foreach (var v in result)
            {
                Console.WriteLine($"The employeeIndex is {v.employeeIndex} and empoyeeName is {v.Name}");
            }
            */
            #endregion

            #region Select Many method
            //Func<Student, List<string>> func = (student) => student.Programming.ToList();
            // var result = Student.GetStudents().AsEnumerable().SelectMany(func);

            // Func<Student, List<string>> func = (student) => student.Programming.ToList();

            // var result = Student.GetStudents().AsEnumerable().SelectMany(func);
            //var result1 = Student.GetStudents().AsEnumerable().SelectMany(x => x.Programming,
            //                                                        (student, programmingLanguage) => new 
            //                                                        { 
            //                                                            StudentName = student.Name, 
            //                                                            Technologies = programmingLanguage 
            //                                                        });
            //foreach (var v in result1)
            //{
            //    Console.WriteLine($"The student techonologies are {v.StudentName}{v.Technologies}");
            //}
            #endregion

            #region Select Many with simple example

            /*remember that inside selectmany itself we have two func. This is not chaining method ok. 
			 1st Func---> Expecting input as string, i.e each person and return IEnumerable<T> 
			 2nd Func---> Expecting input as string, i.e each person + Expecting input as IEnumerable<T> where is T is dataType of previous lambda output
			  and return ananymous type by project new type
            List<string> nameList = new List<string>() { "Pranaya", "Kumar" };
            var methodSyntax = nameList.SelectMany(data => data, (personName, alphabets) => new
            {
                personName = personName,
                alphabets = alphabets
            });

            foreach (var item in methodSyntax)
            {
                Console.WriteLine($"{item.personName} ==> {item.alphabets}");
            }
            Console.ReadKey();*/

            /*OUTPUT
				Pranaya ==> P
				Pranaya ==> r
				Pranaya ==> a
				Pranaya ==> n
				Pranaya ==> a
				Pranaya ==> y
				Pranaya ==> a
				Kumar ==> K
				Kumar ==> u
				Kumar ==> m
				Kumar ==> a
				Kumar ==> r

			 
			 */

            #endregion


            #region SelectMany with new Example

            /*IMP POINT: Func output result is also infered from the output of lambda expression. If we give string as output then the return type
			 * will be of type string 
			 * Ex: Func<string, char, string> func2 = (data, func1) => $"{data}-->{func1}";
			 * There is no such rules like we need to project to new ananymous types like we saw in our previous examples**/

            List<string> nameList = new List<string>() { "Pranaya", "Kumar" };

            Func<string, IEnumerable<char>> func1 = (input) => input;
            Func<string, char, string> func2 = (data, character) => $"{data}-->{character}";

            var methodSyntax = nameList.SelectMany(func1, func2);
            foreach (var item in methodSyntax)
            {
                Console.WriteLine(item);
            }
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

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Programming { get; set; }

        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Email = "James@j.com", Programming = new List<string>() { "C#", "Jave", "C++"} },
                new Student(){ID = 2, Name = "Sam", Email = "Sara@j.com", Programming = new List<string>() { "WCF", "SQL Server", "C#" }},
                new Student(){ID = 3, Name = "Patrik", Email = "Patrik@j.com", Programming = new List<string>() { "MVC", "Jave", "LINQ"} },
                new Student(){ID = 4, Name = "Sara", Email = "Sara@j.com", Programming = new List<string>() { "ADO.NET", "C#", "LINQ" } }
            };
        }
    }
}
