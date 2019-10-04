using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.ApiResources
{
    public class ProductResource
    {
        public ProductResource()
        {
            ProductReviews = new HashSet<ProductReviewResource>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }

        public string Color { get; set; }

        public string ListPrice { get; set; }
        public string Size { get; set; }

        public string Style { get; set; }

        public string ProductModelId { get; set; }

        public virtual ProductModelResource ProductModel { get; set; }

        public virtual ICollection<ProductReviewResource> ProductReviews { get; set; }
    }
}
