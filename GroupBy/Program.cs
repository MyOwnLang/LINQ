using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region using extension method
            //------------------Groupby looping inner----------------------------------------
            /* 
             DataTable dt = CreateDataTable();
             IEnumerable<IGrouping<string,DataRow>> result = dt.AsEnumerable().GroupBy(row => row.Field<string>("Gender"));
             //var result = dt.AsEnumerable().GroupBy(row => row.Field<string>("Gender")).Select(row => row.AsEnumerable().OrderBy(r => r.Field<string>("FirstName")));
             foreach (var item in result)
             {
                 Console.WriteLine($"{item.Key} \t {item.Count()}");
                 Console.WriteLine("-----------------");

                 var sorted = item.AsEnumerable().OrderBy(row => row.Field<string>("FirstName"));
                 foreach (var res in sorted)
                 {
                     Console.WriteLine(res.Field<string>("FirstName"));
                 }
                 Console.WriteLine();
             }
            

            
            DataTable dt = CreateDataTable();
            var result = dt.AsEnumerable().GroupBy(row => row.Field<string>("Gender")).Select(row => new
            {
                KEY = row.Key,
                empRow = row.OrderBy(r => r.Field<string>("FirstName"))

            });
            foreach (var item in result)
            {
                Console.WriteLine($"{ item.KEY} \t {item.empRow.Count()}");
                Console.WriteLine("-----------------");
                foreach (var res in item.empRow)
                {
                    Console.WriteLine(res.Field<string>("FirstName"));
                }
                Console.WriteLine();
            } */
            #endregion

            #region using sql server linq
            //----------------Get Employee Count By Department-------------------
            //var result = from employee in CreateDataTable().AsEnumerable()
            //             group employee by employee.Field<string>("Department");

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Key} \t {item.Count()}");
            //}

            //------------------Get Employee Count By Department and also each employee and department name-------------

            //var result = from employee in CreateDataTable().AsEnumerable()
            //             group employee by employee.Field<string>("Department");

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Key} \t {item.Count()}");
            //    Console.WriteLine("----------");
            //    foreach (var employee in item)
            //    {
            //        Console.WriteLine($"{employee.Field<string>("Name")}\t{employee.Field<string>("Department")}");
            //    }
            //    Console.WriteLine(); Console.WriteLine();
            //}


            //---------------Get Employee Count By Department and also each employee and department name. Data should be sorted first by Department in ascending order and then by Employee Name in ascending order.-------------

            //var result = from employee in CreateDataTable().AsEnumerable()
            //             group employee by employee.Field<string>("Department") into empGroup
            //             orderby empGroup.Key descending
            //             select new
            //             {
            //                 KEY = empGroup.Key,
            //                 Employees = empGroup.OrderByDescending(row => row.Field<string>("Name"))
            //             };


            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.KEY} \t {item.Employees.Count()}");
            //    Console.WriteLine("----------");
            //    foreach (var employee in item.Employees)
            //    {
            //        Console.WriteLine($"{employee.Field<string>("Name")}\t{employee.Field<string>("Department")}");
            //    }
            //    Console.WriteLine(); Console.WriteLine();
            //}



            #endregion

            #region multiple group
            #region using extension method

            //--Group employees by Department and then by Gender. The employee groups should be sorted first by Department and then by Gender in ascending order. 
            //Also, employees within each group must be sorted in ascending order by Name.

         //   DataTable dt = CreateDataTable();
         //   var result = dt.AsEnumerable()
         //                .GroupBy(x => new { Department = x.Field<string>("Department"), Gender = x.Field<string>("Gender") })
         //                .OrderBy(y =>y.Key.Department).ThenBy(z=>z.Key.Gender)
         //                .Select (row => new
         //                {
         //                    Dept = row.Key.Department,
         //                    Gen = row.Key.Gender,
         //                    Employees = row
         //                });
                                                           

         //   foreach (var group in result)
         //   {
         //       Console.WriteLine("{0} department {1} employees count = {2}",
         //group.Dept, group.Gen, group.Employees.Count());
         //       Console.WriteLine("--------------------------------------------");
         //       foreach (var employee in group.Employees)
         //       {
         //           Console.WriteLine(employee.Field<string>("Name") + "\t" + employee.Field<string>("Gender")
         //               + "\t" + employee.Field<string>("Department"));
         //       }
         //       Console.WriteLine(); Console.WriteLine();
         //   }
            #endregion

            #region sql server
            DataTable dt = CreateDataTable();
            var result = from empRow in dt.AsEnumerable()
                         group empRow by new { Department = empRow.Field<string>("Department"), Gender = empRow.Field<string>("Gender") } into eGroup
                         orderby eGroup.Key.Department, eGroup.Key.Gender
                         select new
                         {
                             Dept = eGroup.Key.Department,
                             Gen = eGroup.Key.Gender,
                             Employees = eGroup.OrderBy(x => x.Field<string>("Name"))
                         };

            foreach (var group in result)
            {
                Console.WriteLine("{0} department {1} employees count = {2}",
         group.Dept, group.Gen, group.Employees.Count());
                Console.WriteLine("--------------------------------------------");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.Field<string>("Name") + "\t" + employee.Field<string>("Gender")
                        + "\t" + employee.Field<string>("Department"));
                }
                Console.WriteLine(); Console.WriteLine();
            }

            #endregion
            #endregion
            Console.ReadLine();
        }

        private static DataTable CreateDataTable()
        {
            DataTable employeeData = new DataTable("Employee");
            employeeData.Columns.Add("ID", typeof(int));
            employeeData.Columns.Add("Name", typeof(string));
            employeeData.Columns.Add("Gender", typeof(string));
            employeeData.Columns.Add("Department", typeof(string));
            employeeData.Columns.Add("Salary", typeof(int));


            employeeData.Rows.Add(1, "Mark","Male", "IT",45000);
            employeeData.Rows.Add(2, "Steve", "Male", "HR", 55000);
            employeeData.Rows.Add(3, "Ben","Male","IT", 65000);
            employeeData.Rows.Add(4, "Philip", "Male","IT", 55000);
            employeeData.Rows.Add(5, "Mary", "Female", "HR", 48000);
            employeeData.Rows.Add(6, "Valarie", "Female", "HR", 70000);
            employeeData.Rows.Add(7, "John", "Male", "IT", 64000);
            employeeData.Rows.Add(8, "Pam", "Female", "IT", 54000);
            employeeData.Rows.Add(9, "Stacey", "Female", "HR", 84000);
            employeeData.Rows.Add(10, "Andy", "Male", "IT", 36000);


            return employeeData;

        }
    }
}
