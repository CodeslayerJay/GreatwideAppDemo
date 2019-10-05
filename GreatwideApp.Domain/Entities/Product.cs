using System;
using System.Collections.Generic;

namespace GreatwideApp.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductReviews = new HashSet<ProductReview>();
        }

        
        public int ProductId { get; set; }
        
        public string Name { get; set; }
        
        public string ProductNumber { get; set; }
        
        public bool MakeFlag { get; set; }
        
        public bool FinishedGoodsFlag { get; set; } = true;
        
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; } = 5;
        public short ReorderPoint { get; set; } = 1;
        
        public decimal StandardCost { get; set; }
        
        public decimal ListPrice { get; set; }
        
        public string Size { get; set; }
        
        public string SizeUnitMeasureCode { get; set; }
        
        public string WeightUnitMeasureCode { get; set; }
        
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
       
        public string ProductLine { get; set; }
        
        public string Class { get; set; }
        
        public string Style { get; set; }
        
        public int? ProductModelId { get; set; }

        public DateTime SellStartDate { get; set; } = DateTime.Now;
        
        public DateTime? SellEndDate { get; set; }
        
        public DateTime? DiscontinuedDate { get; set; }
        
        public Guid Rowguid { get; set; }
        
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public ProductModel ProductModel { get; set; }

        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        
        
    }
}
