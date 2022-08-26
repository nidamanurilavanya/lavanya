using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace coremvc.Models
{
    public class HRContext : DbContext
    {

        public HRContext(DbContextOptions<HRContext> option) : base (option)
        {

        }


        public Dbset<Employee> Employee { get; set; }







    }
    
}
