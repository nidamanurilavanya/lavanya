using Microsoft.EntityFrameworkCore;
namespace model_view_controller.Models
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> option) : base(option)
        {

        }
        public DbSet<Employee>Employees { get; set; }

    }
}
