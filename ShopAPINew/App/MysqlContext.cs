using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopMVCAPINew.App {
    public class MysqlContext : DbContext {

        public static MysqlContext Instance = new MysqlContext();

        public MysqlContext()
            : base("MysqlConnection") {
            Database.SetInitializer(new NullDatabaseInitializer<MysqlContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Models.Product>().Map(m => {
                m.ToTable("Product");
                m.Requires(p => p.Name);
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.Product> Products { get; set; } 

        //public 
    }
}