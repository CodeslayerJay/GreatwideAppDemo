using FluentValidation;
using GreatwideApp.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.Validators
{
    internal class ProductValidator : BaseValidator<ProductFormModel>
    {
        public ProductValidator()
        {

            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().MaximumLength(50);

            RuleFor(x => x.ProductNumber).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Product Number is required.")
                .MaximumLength(25);

            RuleFor(x => x.Color).Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(15);

            RuleFor(x => x.ListPrice).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("List Price is required.")
                .Must(ListPrice => PriceMustBeACurrency(ListPrice.ToString()))
                    .WithMessage("List price may include only numbers, commas, and decimals.")
                .Must(ListPrice => PriceMustBeGreaterThanZero(ListPrice.ToString()))
                    .WithMessage("List price must be greater than 0.");



            RuleFor(x => x.SellStartDate).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Sell Start Date is required.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Date must be today or later.");
        }
    }
}
