using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.models
{
    internal class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int deptID { get; set; }
    }

    internal class Departement
    {
        public int id { get; set; }

        public string name { get; set; }


        public int dept { get; set; }
    }
}


    

