using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    public class EmployeeContext :DbContext

    {
        public EmployeeContext(DbContextOptions<EmployeeContext>option) : base(option)
        {
           
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
