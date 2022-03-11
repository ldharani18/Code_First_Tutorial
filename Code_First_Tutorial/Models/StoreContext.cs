using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Code_First_Tutorial.Models
{
    public class StoreContext : DbContext
    {
        //Product->model class;Products->Table
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<Role> Roles { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Supplier> Suppliers { get; set;}
        public DbSet<Slider> Sliders { get; set;}
    }
}