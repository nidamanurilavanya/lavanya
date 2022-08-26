using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication14.Models
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


        public bool check { get; set; } = false;
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
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> option) : base(option)
        {

        }

        public DbSet<Category> categorys { get; set; }


        public DbSet<product> products { get; set; }


        public DbSet<cart> carts { get; set; }
    }
}

