using GreatwideApp.Domain.Interfaces;
using GreatwideApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreatwideApp.Domain.Entities;

namespace GreatwideApp.Domain.Specifications.ProductSpecs
{
    internal class ProductNumberIsUniqueSpec : ISpecification<Product>
    {
        private IUnitOfWork _unitOfWork;

        public ProductNumberIsUniqueSpec(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsSatisfiedBy(Product candidate)
        {
            var product = _unitOfWork.Products.Find(x => x.ProductNumber == candidate.ProductNumber).SingleOrDefault();

            if (product == null)
                return true;

            return product.ProductId == candidate.ProductId;
        }
    }
}
