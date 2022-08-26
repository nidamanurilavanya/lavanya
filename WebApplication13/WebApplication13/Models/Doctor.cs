using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication13.Models
{
    public class Doctor
    {
        public int id { get; set; }


        public string name { get; set; }
 
    
       public string speciality { get; set; }
    }

    public class patient
    {
        public int id { get; set; }

        public string name { get; set; }    

        public string mob { get; set; }
    }


    public class Appointement
    {
        public int id { get; set; }
        [ForeignKey("pt")]

        public int ptid { get; set; }


        public patient pt { get; set; }
       [ ForeignKey("doc")]

        public int docid { get; set; }

        public  Doctor doc { get; set; }

        public DateTime AppointDate { get; set; }
    }

   
    public class HosptialContext : DbContext
    {
        public HosptialContext(DbContextOptions<HosptialContext> option) : base (option)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<patient> patients { get; set; }

        public DbSet<Appointement> appointements { get; set; }

    }

    
}
