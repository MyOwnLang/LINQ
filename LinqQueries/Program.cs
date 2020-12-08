using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Writing using lambda expression
            List<Student> listStudents = new List<Student>
            {
                new Student {ID = 100, Name = "Mark", Gender = "Male"},
                new Student {ID = 101, Name = "Sara", Gender = "Female"},
                new Student {ID = 102, Name = "John", Gender = "Male"},
                new Student {ID = 103, Name = "Henry", Gender = "Male"},
            };

            var resultStudents = listStudents.Where(student => student.Gender == "Male");
            Console.WriteLine($"Male students");
            Console.WriteLine("===============");
            foreach (var student in resultStudents)
            {
                Console.WriteLine(student.Name);
            }
            */


/*Writing using linq query operators*/
            List<Student> list = new List<Student>
            {
                new Student(100, "Mike", "Male"),
                new Student(200, "Steve", "Male"),
                new Student(300, "Chris", "Male"),
                new Student(400, "Juli", "Female"),
            };

            var result = from n in list
                where n.Gender == "Male"
                select n;
            Console.WriteLine($"Male students");
            Console.WriteLine("===============");
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadLine();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public Student(int id, string name, string gender)
        {
            ID = id;
            Name = name;
            Gender = gender;
        }
    }
}
