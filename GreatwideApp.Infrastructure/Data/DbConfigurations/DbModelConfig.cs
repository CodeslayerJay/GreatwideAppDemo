using GreatwideApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Infrastructure.Data.DbConfigurations
{
    public class DbModelConfig
    {
        private readonly ModelBuilder _modelBuilder;

        public DbModelConfig(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }


        public void ConfigureProduct()
        {
            var entity = _modelBuilder.Entity<Product>();

            entity.ToTable("Product", "Production");

            entity.HasIndex(e => e.Name)
                .HasName("AK_Product_Name")
                .IsUnique();

            entity.HasIndex(e => e.ProductNumber)
                .HasName("AK_Product_ProductNumber")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_Product_rowguid")
                .IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.Class).HasMaxLength(2);

            entity.Property(e => e.Color).HasMaxLength(15);

            entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

            entity.Property(e => e.FinishedGoodsFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.ListPrice).HasColumnType("money");

            entity.Property(e => e.MakeFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.ProductLine).HasMaxLength(2);

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

            entity.Property(e => e.ProductNumber)
                .IsRequired()
                .HasMaxLength(25);

            //entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

            entity.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.SellEndDate).HasColumnType("datetime");

            entity.Property(e => e.SellStartDate).HasColumnType("datetime");

            entity.Property(e => e.Size).HasMaxLength(5);

            entity.Property(e => e.SizeUnitMeasureCode).HasMaxLength(3);

            entity.Property(e => e.StandardCost).HasColumnType("money");

            entity.Property(e => e.Style).HasMaxLength(2);

            entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");

            entity.Property(e => e.WeightUnitMeasureCode).HasMaxLength(3);

        }

        public void ConfigureProductModel()
        {
            _modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("ProductModel", "Production");

                entity.HasIndex(e => e.CatalogDescription)
                    .HasName("PXML_ProductModel_CatalogDescription");

                entity.HasIndex(e => e.Instructions)
                    .HasName("PXML_ProductModel_Instructions");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductModel_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductModel_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.CatalogDescription).HasColumnType("xml");

                entity.Property(e => e.Instructions).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

        }

        public void ConfigureProductReview()
        {
            _modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.ToTable("ProductReview", "Production");

                entity.HasIndex(e => new { e.Comments, e.ProductId, e.ReviewerName })
                    .HasName("IX_ProductReview_ProductID_Name");

                entity.Property(e => e.ProductReviewId).HasColumnName("ProductReviewID");

                entity.Property(e => e.Comments).HasMaxLength(3850);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }

        public void ConfigureProductDescription()
        {
            var entity = _modelBuilder.Entity<ProductDescription>();

            entity.ToTable("ProductDescription", "Production");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_ProductDescription_rowguid")
                .IsUnique();

            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(400);

            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())");
        }
    }
}
