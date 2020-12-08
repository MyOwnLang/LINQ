using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace LinqExtensionMethods
{

    /*If you dont use sql sever like syntax then you must use extension method and with lambda expression*/

    public class Student
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Subject { get; set;}    


        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Name = "Alex",
                    Gender = "Male",
                    Subject = new List<string>
                    {
                        "WCF","C#",".NETCORE"
                    }
                },

                new Student
                {
                    Name = "Putin",
                    Gender = "Male",
                    Subject = new List<string>
                    {
                        "Cloud","C#","Python"
                    }
                },

                new Student
                {
                    Name = "James",
                    Gender = "Male",
                    Subject = new List<string>
                    {
                        "Javascript","Java",".NETCORE"
                    }
                },

                new Student
                {
                    Name = "Palimeli",
                    Gender = "Female",
                    Subject = new List<string>
                    {
                        "NodeJS","ASP.NET","Angular"
                    }
                },

                new Student
                {
                    Name = "Rusev",
                    Gender = "Male",
                    Subject = new List<string>
                    {
                        "WCF","C#",".NETCORE"
                    }
                }
            };

            return students;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Student> students = new List<Student> //we can give() here or we can remove also
            {
                new Student //we can give() here or we can remove also
                {
                    Name = "Mark",
                    Gender = "Male"
                }, // here , is needed because every list values should be separted by comma Ex: Lis<string> values = new List<string>{ "a" , "B"};

                new Student
                {
                    Name = "Steve",
                    Gender = "Male"
                },

                new Student
                {
                    Name = "AmandaPrince",
                    Gender = "Female"
                },

                new Student
                {
                    Name = "Austin",
                    Gender = "Male"
                },
            };


            foreach (var item in students)
            {
              //  Console.WriteLine(item.Name + " - " + item.Gender);
            }

            #region Projection Select

            #region result would contain anonymous objects
            /*
            DataTable dataTable = CreateDataTable();
            var result = dataTable.AsEnumerable().Select(emp => new //select is like "SELECT statement in SQL query : you can create new columns/properties, append to exisitng column, perform calculation on the fly etc
            {
                EmployeeName = emp.Field<string>("Gender") == "Male" ? "Mr " + emp.Field<string>("FirstName") : "Ms " + emp.Field<string>("FirstName"),
                Born = emp.Field<DateTime>("DOB"),
            });

            foreach (var item in result)
            {
                Console.WriteLine($"The employee name is {item.EmployeeName} , DOB is { item.Born}");
            }
            */


            #endregion

            #region Fetch all EmployeeID directly using Func Delegate
            /*
            DataTable dataTable = CreateDataTable();
            Func<DataRow, int> funcDelegate = (empRow) => empRow.Field<int>("EmployeeID");
            IEnumerable<int> result = dataTable.AsEnumerable().Select(funcDelegate);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            */
            #endregion

            #region  Example 2: Projects FirstName & Gender properties of all employees into anonymous type.

            /*
            DataTable dataTable = CreateDataTable();
            var result = dataTable.AsEnumerable().Select(emp => new
            {
                FirstName = emp.Field<string>("FirstName"),
                Gender = emp.Field<string>("Gender")
            });

            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName + " - " + item.Gender);
            }
              */
            #endregion

            #region Example 3: Computes FullName and MonthlySalay of all employees and projects these 2 new computed properties into anonymous type.
            /*
            DataTable dataTable = CreateDataTable();
            var result = dataTable.AsEnumerable().Select(emp => new
            {
                FullName = emp.Field<string>("FirstName") + emp.Field<string>("LastName"),
                yearOfBirth = emp.Field<DateTime>("DOB").ToString("yyyy")
            });

            foreach (var item in result)
            {
                Console.WriteLine(item.FullName + " - " + item.yearOfBirth);
            }
            */
            #endregion
            #endregion

            #region Projection SelectMany
            /*
            var studentResult = Student.GetAllStudents().Select(stud => stud.Name);
            foreach (var item in studentResult)
            {
                Console.WriteLine(item);
            }
            var studentMany = Student.GetAllStudents().SelectMany(stud => stud.Subject);
            foreach (var item in studentMany)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region Where

            /*
            DataTable dataTable = CreateDataTable();

             // Func<DataRow, bool> predicate = x => x.Field<string>("FirstName").Equals("Mark",StringComparison.OrdinalIgnoreCase); //passing as Func predicate
             // EnumerableRowCollection<DataRow> result = dataTable.AsEnumerable().Where(predicate);//passing as Func predicate

             // EnumerableRowCollection<DataRow> result = dataTable.AsEnumerable().Where(x => x.Field<string>("Name") == "Mark"); //I was able to write lambda expression inside where() because where expects Fucn<Datarow, bool> delegate

             //EnumerableRowCollection<DataRow> result = dataTable.AsEnumerable().Where(row => IsEmployeeExists(row));//passing as Function

             // var result = dataTable.AsEnumerable().Select((row, index) => new { Row = row, Index = index }).Where(r => Regex.IsMatch(r.Row.Field<string>("FirstName"), @"^h", RegexOptions.IgnoreCase)); //prints names with its corresponding index

             // IEnumerable<DataRow> result = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName").Equals("Mark", StringComparison.OrdinalIgnoreCase));
             // IEnumerable<DataRow> result = dataTable.AsEnumerable().Where(row => Regex.IsMatch(row.Field<string>("FirstName"), @"^hanna.*", RegexOptions.IgnoreCase));
            // IEnumerable<DataRow> result = dataTable.AsEnumerable().Where(row => Regex.IsMatch(row.Field<string>("FirstName"), @"^hanna-[^L].*", RegexOptions.IgnoreCase));

             IEnumerable<DataRow> result = dataTable.AsEnumerable().Where(row => Regex.IsMatch(row.Field<string>("FirstName"), @"^hanna-[^L].*", RegexOptions.IgnoreCase) &&
             row.Field<string>("Gender") == "Female");
             if (result.Any())
             {
                 foreach (var item in result)
                 {
                     string employee = item["FirstName"].ToString();
                     Console.WriteLine(employee);
                 }

             }
            */
            #endregion

            #region Orderby UsingExtension Method syntax
            //DataTable dataTable = CreateDataTable();
            //var result = dataTable.AsEnumerable().OrderBy(row => row.Field<string>("FirstName"));

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName"));
            //}

            //DataTable dataTable = CreateDataTable();
            //var result = dataTable.AsEnumerable().OrderByDescending(row => row.Field<string>("FirstName"));

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName"));
            //}

            //DataTable dataTable = CreateDataTable();
            //var result = dataTable.AsEnumerable().OrderBy(row => row.Field<string>("FirstName")).ThenBy(row => row.Field<string>("LastName"));

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName") + " - " + item.Field<string>("LastName"));
            //}
            #endregion

            #region Orderby Using sql server like syntax
            /*
            DataTable dataTable = CreateDataTable();
            var result = from row in dataTable.AsEnumerable()
                         orderby row.Field<string>("FirstName") descending
                         select row;

            foreach (var item in result)
            {
                Console.WriteLine(item.Field<string>("FirstName"));
            }
            */
            //DataTable dataTable = CreateDataTable();
            //var result = from row in dataTable.AsEnumerable()
            //             orderby row.Field<string>("FirstName"), row.Field<string>("LastName") descending
            //             select row;

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName") + " - " + item.Field<string>("LastName"));
            //}

            #endregion

            #region Partitioning Operators in LINQ
            //------------------Take----------------------------------------

            //DataTable dataTable = CreateDataTable();
            //var result = dataTable.AsEnumerable().Take(3); //returns the first three rows
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName"));
            //}

            //DataTable dataTable = CreateDataTable();
            //var result = (from row in dataTable.AsEnumerable()
            //              select row).Take(3);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName"));
            //}

            //------------------skip----------------------------------------

            //DataTable dataTable = CreateDataTable();
            //var result = dataTable.AsEnumerable().Skip(3); //skips the first three rows
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName"));
            //}

            //DataTable dataTable = CreateDataTable();
            //var result = (from row in dataTable.AsEnumerable()
            //              select row).Skip(3);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName"));
            //}

            //------------------takeWhile----------------------------------------
            //DataTable dataTable = CreateDataTable();
            //var result = dataTable.AsEnumerable().TakeWhile(row => row.Field<string>("FirstName").Length > 2); //returns all the rows untill the condition is true, after failing the condition will come out from loop
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName"));
            //}
            //------------------skipWhile----------------------------------------

            //DataTable dataTable = CreateDataTable();
            //var result = dataTable.AsEnumerable().SkipWhile(row => row.Field<string>("FirstName").Length > 2); //skips all the rows untill the condition is true, after failing the condition it will returns rest of the rows
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Field<string>("FirstName"));
            //}
            #endregion


            Console.ReadKey();
        }

        private static bool IsEmployeeExists(DataRow dr)
        {
            return Regex.IsMatch(dr.Field<string>("FirstName"), @"^h",RegexOptions.IgnoreCase);
           //return string.Format("MM/dd/yyyy",dr.Field<DateTime>("DOB"));
        }

        private static DataTable CreateDataTable()
        {
            DataTable employeeData = new DataTable("Employee");
            employeeData.Columns.Add("EmployeeID", typeof(int));
            employeeData.Columns.Add("FirstName", typeof(string));
            employeeData.Columns.Add("LastName", typeof(string));
            employeeData.Columns.Add("Gender", typeof(string));
            employeeData.Columns.Add("DOB", typeof(DateTime));

           
            employeeData.Rows.Add(101, "Tom", "Daley", "Male", new DateTime(1988, 12, 12));
            employeeData.Rows.Add(102, "Alexa", "Bliss", "Female",new DateTime(1991, 07, 24));
            employeeData.Rows.Add(103, "Mark", "Butcher", "Male",new DateTime(1988, 08, 4));
            employeeData.Rows.Add(104, "Henry", "Kilsmen", "Male", new DateTime(1988, 06, 23));
            employeeData.Rows.Add(105, "Hanna-esi", "grimse", "male", new DateTime(1978, 02, 12));
            employeeData.Rows.Add(100, "Su", "Daley", "Male", new DateTime(1988, 12, 12));
            employeeData.Rows.Add(106, "Hanna-Last", "castle", "Female", new DateTime(1990, 02, 2));
            employeeData.Rows.Add(107, "Hanna-summer", "castle", "Female", new DateTime(1996, 02, 2));

            return employeeData;

        }
    }
}
