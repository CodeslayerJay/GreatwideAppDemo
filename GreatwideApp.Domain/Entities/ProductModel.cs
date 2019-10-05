using System;
using System.Collections.Generic;

namespace GreatwideApp.Domain.Entities
{
    public partial class ProductModel
    {
        public ProductModel()
        {
            Products = new HashSet<Product>();
        }

        public int ProductModelId { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public string Instructions { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Products { get; set; }
        
    }
}
