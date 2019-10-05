using GreatwideApp.Domain.Entities;
using GreatwideApp.Domain.Interfaces;
using GreatwideApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatwideApp.Domain.Specifications.ProductSpecs
{
    internal class ProductNameIsUniqueSpec : ISpecification<Product>
    {
        private IUnitOfWork _unitOfWork;

        public ProductNameIsUniqueSpec(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsSatisfiedBy(Product candidate)
        {
            var product = _unitOfWork.Products.Find(x => x.Name == candidate.Name).SingleOrDefault();

            if (product == null)
                return true;

            return product.ProductId == candidate.ProductId;
        }
    }
}
