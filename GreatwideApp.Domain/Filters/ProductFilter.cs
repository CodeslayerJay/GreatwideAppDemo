
using GreatwideApp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Filters
{
    public class ProductFilter : AbstractQueryFilter
    {
        public bool IncludeProductModel { get; set; }
        public bool IncludeProductReviews { get; set; }

    }
}
