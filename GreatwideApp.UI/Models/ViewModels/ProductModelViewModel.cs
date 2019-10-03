using System;
using System.Collections.Generic;

namespace GreatwideApp.UI.Models.ViewModels
{
    public class ProductModelViewModel
    {

        public ProductModelViewModel()
        {
            Products = new HashSet<ProductViewModel>();
        }

        public int ProductModelId { get; set; }
        public string Name { get; set; }
        

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}