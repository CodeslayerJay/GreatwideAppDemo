using FluentValidation;
using GreatwideApp.Domain.Interfaces.Services;
using GreatwideApp.Infrastructure.Data;
using GreatwideApp.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.Validators
{
    internal class ProductValidator : BaseValidator<ProductFormModel>
    {
        private readonly IProductService _productService;

        public ProductValidator(IProductService productService)
        {
            _productService = productService;
            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().MaximumLength(50)
                .Must(IsUniqueProductName).WithMessage("A product with that name already exists.");


            RuleFor(x => x.ProductNumber).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Product Number is required.")
                .MaximumLength(25).WithMessage("Product Number must be 1-25 characters long.")
                .Must(IsUniqueProductNumber).WithMessage("A product with that number already exists");

            RuleFor(x => x.Color).Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(15);

            RuleFor(x => x.ListPrice).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("List Price is required.")
                .Must(ListPrice => PriceMustBeACurrency(ListPrice.ToString()))
                    .WithMessage("List price may include only numbers, commas, and decimals.")
                .Must(ListPrice => PriceMustBeGreaterThanZero(ListPrice.ToString()))
                    .WithMessage("List price must be greater than 0.");



            //RuleFor(x => x.SellStartDate).Cascade(CascadeMode.StopOnFirstFailure)
            //    .NotEmpty().WithMessage("Sell Start Date is required.")
            //    .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Date must be today or later.");
        }

        private bool IsUniqueProductName(ProductFormModel formModel, string productName)
        {
            var productToCheck = _productService.GetByProductName(productName);

            if (productToCheck == null)
                return true;

            return productToCheck.ProductId == formModel.ProductId;
        }

        private bool IsUniqueProductNumber(ProductFormModel formModel, string productNumber)
        {
            var productToCheck = _productService.GetByProductNumber(productNumber);
            
            if (productToCheck == null)
                return true;

            return productToCheck.ProductId == formModel.ProductId;
        }
    }
}
