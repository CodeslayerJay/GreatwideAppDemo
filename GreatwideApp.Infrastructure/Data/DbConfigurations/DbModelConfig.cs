﻿using GreatwideApp.Domain.Entities;
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

        //public void ConfigureProduct()
        //{
        //    _modelBuilder.Entity<Product>(entity =>
        //    {
        //        //entity.ToTable("Products");
        //        entity.HasIndex(e => e.Name)
        //            .HasName("AK_Product_Name")
        //            .IsUnique();

        //        entity.HasIndex(e => e.ProductNumber)
        //            .HasName("AK_Product_ProductNumber")
        //            .IsUnique();

        //        entity.HasIndex(e => e.Rowguid)
        //            .HasName("AK_Product_rowguid")
        //            .IsUnique();

        //        entity.Property(e => e.FinishedGoodsFlag).HasDefaultValueSql("((1))");

        //        entity.Property(e => e.MakeFlag).HasDefaultValueSql("((1))");

        //        entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.Rowguid).HasDefaultValueSql("(newid())");
        //    });

        //}

        //public void ConfigureProductDescription()
        //{
        //    _modelBuilder.Entity<ProductDescription>(entity =>
        //    {
        //        entity.HasIndex(e => e.Rowguid)
        //            .HasName("AK_ProductDescription_rowguid")
        //            .IsUnique();

        //        entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.Rowguid).HasDefaultValueSql("(newid())");
        //    });
        //}

        //public void ConfigureProductModel()
        //{
        //    _modelBuilder.Entity<ProductModel>(entity =>
        //    {
        //        entity.HasIndex(e => e.CatalogDescription)
        //            .HasName("PXML_ProductModel_CatalogDescription");

        //        entity.HasIndex(e => e.Instructions)
        //            .HasName("PXML_ProductModel_Instructions");

        //        entity.HasIndex(e => e.Name)
        //            .HasName("AK_ProductModel_Name")
        //            .IsUnique();

        //        entity.HasIndex(e => e.Rowguid)
        //            .HasName("AK_ProductModel_rowguid")
        //            .IsUnique();

        //        entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.Rowguid).HasDefaultValueSql("(newid())");
        //    });

        //}

        //public void ConfigureProductReview()
        //{
        //    _modelBuilder.Entity<ProductReview>(entity =>
        //    {
        //        entity.HasIndex(e => new { e.Comments, e.ProductId, e.ReviewerName })
        //            .HasName("IX_ProductReview_ProductID_Name");

        //        entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.ReviewDate).HasDefaultValueSql("(getdate())");

        //        entity.HasOne(d => d.Product)
        //            .WithMany(p => p.ProductReviews)
        //            .HasForeignKey(d => d.ProductId)
        //            .OnDelete(DeleteBehavior.ClientSetNull);
        //    });
        //}

        public void ConfigureProduct()
        {
            var productEntity = _modelBuilder.Entity<Product>();

            productEntity.ToTable("Product", "Production");

            productEntity.HasIndex(e => e.Name)
                    .HasName("AK_Product_Name")
                    .IsUnique();

            productEntity.HasIndex(e => e.ProductNumber)
                    .HasName("AK_Product_ProductNumber")
                    .IsUnique();

            productEntity.Property(e => e.ProductId).HasColumnName("ProductID");


            productEntity.Property(e => e.Color).HasMaxLength(15);

            productEntity.Property(e => e.ListPrice)
                .HasColumnType("money")
                .IsRequired();

            productEntity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime");


            productEntity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            productEntity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

            productEntity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25);

            productEntity.Property(e => e.Size).HasMaxLength(5);

            productEntity.Property(e => e.Style).HasMaxLength(2);

        }

        public void ConfigureProductModel()
        {
            var productModelEntity = _modelBuilder.Entity<ProductModel>();

            productModelEntity.ToTable("ProductModel", "Production");

            productModelEntity.HasIndex(e => e.CatalogDescription)
                .HasName("PXML_ProductModel_CatalogDescription");

            productModelEntity.HasIndex(e => e.Instructions)
                .HasName("PXML_ProductModel_Instructions");

            productModelEntity.HasIndex(e => e.Name)
                .HasName("AK_ProductModel_Name")
                .IsUnique();

            productModelEntity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

            productModelEntity.Property(e => e.CatalogDescription).HasColumnType("xml");

            productModelEntity.Property(e => e.Instructions).HasColumnType("xml");

            productModelEntity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime");


            productModelEntity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

        }

        public void ConfigureProductReview()
        {
            var productReviewEntity = _modelBuilder.Entity<ProductReview>();

            productReviewEntity.ToTable("ProductReview", "Production");

            productReviewEntity.HasIndex(e => new { e.Comments, e.ProductId, e.ReviewerName })
                .HasName("IX_ProductReview_ProductID_Name");

            productReviewEntity.Property(e => e.ProductReviewId).HasColumnName("ProductReviewID");

            productReviewEntity.Property(e => e.Comments).HasMaxLength(3850);

            productReviewEntity.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);

            productReviewEntity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime");

            productReviewEntity.Property(e => e.ProductId).HasColumnName("ProductID");

            productReviewEntity.Property(e => e.ReviewDate)
                .HasColumnType("datetime");


            productReviewEntity.Property(e => e.ReviewerName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
