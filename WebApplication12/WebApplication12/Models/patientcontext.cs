using Microsoft.EntityFrameworkCore;

namespace WebApplication12.Models
{
    public class patientcontext : DbContext

    {

         
        public patientcontext(DbContextOptions<patientcontext> option) : base(option)
        {

        }
        public DbSet<patient> patients { get; set; }

    }
}

