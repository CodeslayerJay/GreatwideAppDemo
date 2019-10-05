using GreatwideApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Specifications.ProductSpecs
{
    internal class ProductSafetyStockLevelSpec : ISpecification<int>
    {
        private const int SAFETY_STOCK_BASE_LIMIT = 1;

        public bool IsSatisfiedBy(int candidate)
        {
            return candidate >= SAFETY_STOCK_BASE_LIMIT;
        }
    }
}
