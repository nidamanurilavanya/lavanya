using System.Collections.Generic;
using WebApplication11.Models;

namespace Webapplication
{


    internal class program
    {

        static void Main(string[] args)
        {
            Predicate<int> check = Exists;
            bool val = check(3);
            if (val)
            {
                Console.WriteLine("Employee found in database");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
            Console.ReadLine();
        }
        public static bool Exists(int i)
        {
            Employee e1 = new Employee()
            {
                id = 1,
                Name = "lavanya",
                salary = 1000


            };
            Employee e2 = new Employee()
            {
                id = 2,
                Name = " nidaamnuri",
                salary = 2000
            };

            List<Employee> elist = new List<Employee>() { e1, e2 };

            bool check = false;
            if (elist.Where(el => el.id == i).Count() > 0)
            {
                check = true;
            }
            return check;
        }
    }
}