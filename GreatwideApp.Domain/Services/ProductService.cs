using GreatwideApp.Domain.Entities;
using GreatwideApp.Domain.Exceptions;
using GreatwideApp.Domain.Interfaces.Repositories;
using GreatwideApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void SaveProduct(Product product)
        {
            if (product != null)
            {
                if (product.ProductId == 0)
                    _unitOfWork.Products.Add(product);

                _unitOfWork.SaveChanges();
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = _unitOfWork.Products.GetById(productId);

            if (product == null)
                throw new ProductNotFoundException(productId);


            _unitOfWork.Products.Remove(productId);
        }

        public IEnumerable<Product> GetProducts(int size = 100)
        {
            return _unitOfWork.Products.GetAll(size);
        }

        public Product GetProduct(int productId)
        {
            return _unitOfWork.Products.GetById(productId);
        }

    }
}
