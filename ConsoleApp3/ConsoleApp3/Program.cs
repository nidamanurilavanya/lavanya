using System;
using System.Collections.Generic;
using System.Linq;






namespace ConsoleApp3
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            sqlCommand con = new sqlConnection(configurationManger.ConnectionString["MyConnection"].ToString());

         

            List<EmployeeBase> emplist = new List<EmployeeBase>();
            Employee employee = new Employee()
            {
                deptID = 101;
                 name = "Lavanya",
                dept = "Tech"
            }
            

           
            




    
}


}


}