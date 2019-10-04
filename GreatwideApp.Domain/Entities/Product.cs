﻿using System;
using System.Collections.Generic;

namespace GreatwideApp.Domain.Entities
{
    //[Table("Product", Schema = "Production")]
    public partial class Product
    {
        public Product()
        {
            ProductReviews = new HashSet<ProductReview>();
        }

        
        public int ProductId { get; set; }
        //[Required]
        //[StringLength(50)]
        public string Name { get; set; }
        //[Required]
        //[StringLength(25)]
        public string ProductNumber { get; set; }
        //[Required]
        public bool? MakeFlag { get; set; }
        //[Required]
        public bool? FinishedGoodsFlag { get; set; }
        //[StringLength(15)]
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        //[Column(TypeName = "money")]
        public decimal StandardCost { get; set; }
        //[Column(TypeName = "money")]
        public decimal ListPrice { get; set; }
        //[StringLength(5)]
        public string Size { get; set; }
        //[StringLength(3)]
        public string SizeUnitMeasureCode { get; set; }
        //[StringLength(3)]
        public string WeightUnitMeasureCode { get; set; }
        //[Column(TypeName = "decimal(8, 2)")]
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        //[StringLength(2)]
        public string ProductLine { get; set; }
        //[StringLength(2)]
        public string Class { get; set; }
        //[StringLength(2)]
        public string Style { get; set; }
        
        public int? ProductModelId { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime SellStartDate { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime? SellEndDate { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime? DiscontinuedDate { get; set; }
        //[Column("rowguid")]
        public Guid Rowguid { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        public ProductModel ProductModel { get; set; }

        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        
        
    }
}
