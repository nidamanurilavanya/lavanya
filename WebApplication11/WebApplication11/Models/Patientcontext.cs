using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    public class Patientcontext : DbContext

    {
        public Patientcontext(DbContextOptions<Patientcontext> option) : base(option)
        {

        }
        public DbSet<patient> patients { get; set; }

    }
}
