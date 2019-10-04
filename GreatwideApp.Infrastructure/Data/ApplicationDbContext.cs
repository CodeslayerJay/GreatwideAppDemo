using System;
using GreatwideApp.Domain.Entities;
using GreatwideApp.Infrastructure.Data.DbConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GreatwideApp.Infrastructure.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Define our models to map from database schema using configurations
            var dbConfig = new DbModelConfig(modelBuilder);
            //dbConfig.ConfigureProduct();
            dbConfig.ConfigureProductModel();
            dbConfig.ConfigureProductReview();

            base.OnModelCreating(modelBuilder);
        }
    }
}
