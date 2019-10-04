using System.Collections.Generic;

namespace GreatwideApp.UI.Models.ApiResources
{
    public class ProductModelResource
    {
        public ProductModelResource()
        {
            Products = new HashSet<ProductResource>();
        }

        public int ProductModelId { get; set; }
        public string Name { get; set; }


        public virtual ICollection<ProductResource> Products { get; set; }
    }
}