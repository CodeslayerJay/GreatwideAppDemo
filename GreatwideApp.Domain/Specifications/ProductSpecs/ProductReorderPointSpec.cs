using GreatwideApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Specifications.ProductSpecs
{
    internal class ProductReorderPointSpec : ISpecification<int>
    {
        private const int REORDER_BASE_LIMIT = 1;

        public bool IsSatisfiedBy(int candidate)
        {
            return candidate >= REORDER_BASE_LIMIT;
        }
    }
}
