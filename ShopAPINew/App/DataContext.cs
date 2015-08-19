using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopMVCAPINew.App {
    public class DataContext :DbContext{

        public static DataContext Instance = new DataContext();

        public DataContext()
            : base("DefaultConnection") {
            Database.SetInitializer<DataContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Entity<Models.Product>().Map(m => {
                m.ToTable("Product");
                m.Requires(e => e.Name);
            });

            modelBuilder.Entity<Models.User>().Map(u => u.ToTable("SiteUser"));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.Product> Products { get; set; }

        public DbSet<Models.User> Users { get; set; } 
    }
}