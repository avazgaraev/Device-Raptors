using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication21.Models
{
    public class context : DbContext
    {
        public DbSet<admin> Admins { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<subcategory> subcategories{ get; set; }
        public DbSet<customer> Customers{ get; set; }
        public DbSet<products> Products{ get; set; }
        public DbSet<salemove> Salemoves{ get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<kargo> kargos{ get; set; }
        public DbSet<kargofollow> kargofollows{ get; set; }
        public DbSet<messages> messages{ get; set; }
        public DbSet<sliders> sliders{ get; set; }
        public DbSet<contact> contacts{ get; set; }
        public DbSet<sliderright> sliderrights{ get; set; }
        public DbSet<altbanner> altbanners{ get; set; }
        public DbSet<prodsize> prodsizes{ get; set; }
        public DbSet<prodcolor> prodcolors{ get; set; }
        public DbSet<prodimg> prodimgs{ get; set; }
        public DbSet<basket> baskets{ get; set; }
        public DbSet<cusaddress> cusaddresses{ get; set; }
    }
}