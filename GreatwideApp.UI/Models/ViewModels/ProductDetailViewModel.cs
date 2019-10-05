using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Product { get; set; }
        public IEnumerable<ProductReviewViewModel> ProductReviews { get; set; }
    }
}
