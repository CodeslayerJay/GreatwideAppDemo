using System;
using System.Collections.Generic;

namespace GreatwideApp.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductReview = new HashSet<ProductReview>();
            
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        
        public string Color { get; set; }
        
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        
        public string Style { get; set; }
        
        public int? ProductModelId { get; set; }
        
        public DateTime ModifiedDate { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        
        public virtual ICollection<ProductReview> ProductReview { get; set; }
        
    }
}
