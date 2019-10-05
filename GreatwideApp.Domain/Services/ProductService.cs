using GreatwideApp.Domain.Entities;
using GreatwideApp.Domain.Exceptions;
using GreatwideApp.Domain.Interfaces.Repositories;
using GreatwideApp.Domain.Interfaces.Services;
using GreatwideApp.Domain.Specifications.ProductSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ProductReview> GetProductReviews(int productId, int size = 10)
        {
            return _unitOfWork.Products.GetProductReviews(productId, size);
        }

        public int GetProductCount()
        {
            return _unitOfWork.Products.GetCount();
        }
        public Product GetByProductNumber(string productNumber)
        {
            return _unitOfWork.Products.Find(x => x.ProductNumber == productNumber).SingleOrDefault();
        }

        public Product GetByProductName(string productName)
        {
            return _unitOfWork.Products.Find(x => x.Name == productName).SingleOrDefault();
        }

        public IEnumerable<ProductModel> GetAllProductModels()
        {
            return _unitOfWork.Products.GetAllProductModels();
        }

        public void SaveProduct(Product product)
        {
            if (product != null)
            {
                VerifyProductSpecifications(product);

                if (product.ProductId == 0)
                    _unitOfWork.Products.Add(product);

                _unitOfWork.SaveChanges();
            }
        }

        //==========================================================================
        // Business Rules and Specifications Checks
        // These specs are based off the requirements and checks that
        // the SQL Database has. SQL Connection will throw exceptions if
        // these requirements are not met.
        //
        // The entitiy has default values, plsut the data model has checks and validation, 
        // however the defaults can be overriden. Check if values meet requirements.
        
        private void VerifyProductSpecifications(Product product)
        {

            var productNameIsUniqueSpec = new ProductNameIsUniqueSpec(_unitOfWork);
            if (!productNameIsUniqueSpec.IsSatisfiedBy(product))
                throw new ProductSpecException("Product Name must be unique.");

            var productNumberIsUniqueSpec = new ProductNumberIsUniqueSpec(_unitOfWork);
            if (!productNumberIsUniqueSpec.IsSatisfiedBy(product))
                throw new ProductSpecException("Product Number must be unique.");

            var productSafetyStockLevelSpec = new ProductSafetyStockLevelSpec();
            if (!productSafetyStockLevelSpec.IsSatisfiedBy(product.SafetyStockLevel))
                throw new ProductSpecException("Product Safety Stock Level must be greater than 0.");

            var productReorderPointSpec = new ProductReorderPointSpec();
            if (!productReorderPointSpec.IsSatisfiedBy(product.ReorderPoint))
                throw new ProductSpecException("Product Reorder Point must be greater than 0.");

        }

        public void DeleteProduct(int productId)
        {
            var product = _unitOfWork.Products.GetById(productId);

            if (product == null)
                throw new ProductNotFoundException(productId);


            _unitOfWork.Products.Remove(productId);
        }

        public IEnumerable<Product> GetProducts(int skip = 0, int size = 30)
        {
            if (size <= 0 || size > 300)
                size = 30;

            if (skip < 0)
                skip = 0;

            return _unitOfWork.Products.GetAll(skip, size);
        }

        public Product GetProduct(int productId)
        {
            return _unitOfWork.Products.GetById(productId);
        }

    }
}
