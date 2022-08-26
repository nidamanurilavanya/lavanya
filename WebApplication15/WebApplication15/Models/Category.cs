using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication15.Models
{
    public class Category
    {
        public int id { get; set; }


        public string? name { get; set; }
    }

    public class product
    {

        public int id { get; set; }

        public string name { get; set; }
        [ForeignKey("categ")]

        public int categID { get; set; }

        public Category? categ { get; set; }
        public bool check { get; internal set; }
    }

    public class cart
    {
        public int id { get; set; }
        [ForeignKey("prod")]

        public int prodID { get; set; }
        [ForeignKey("categ")]

        public int categid { get; set; }

        public Category? categ { get; set; }

        public string user { get; set; }

        public DateTime dt { get; set; }
    }

    public class CategoriesContext : DbContext
    {
        public CategoriesContext(DbContextOptions<CategoriesContext>option) : base(option)
        {

        }
        public DbSet<Category> categorys { get; set; }


        public DbSet<product> products { get; set; }


        public DbSet<cart> carts { get; set; }
    }
}
