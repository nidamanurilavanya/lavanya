using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class ApplicationHRContext : IdentityDbContext
    {
        public ApplicationHRContext(DbContextOptions<ApplicationHRContext> options)
            : base(options)
        {
        }
    }
}