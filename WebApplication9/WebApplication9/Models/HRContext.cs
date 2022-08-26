
using Microsoft.EntityFrameworkCore;

namespace WebApplication9.Models
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> option) : base(option)
        {

        }


        public DbSet<Employee> Employees { get; set; }
    }
}
