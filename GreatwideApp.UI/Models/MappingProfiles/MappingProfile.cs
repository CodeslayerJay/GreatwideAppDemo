using AutoMapper;
using GreatwideApp.Domain.Entities;
using GreatwideApp.Domain.Interfaces.Services;
using GreatwideApp.UI.Models.ApiResources;
using GreatwideApp.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IProductService productService)
        {
            // Product Mappings
            CreateMap<Product, ProductViewModel>()
                .ForMember(viewModel => viewModel.AverageRating, opts => opts.MapFrom(v => productService.GetAverageProductRating(v.ProductReviews)));

            CreateMap<Product, ProductFormModel>();
            CreateMap<ProductFormModel, Product>();
            CreateMap<Product, ProductResource>();

            // Product Model Mappings
            CreateMap<ProductModel, ProductModelViewModel>();
            CreateMap<ProductModel, ProductModelResource>();

            // Product Review Mappings
            CreateMap<ProductReview, ProductReviewViewModel>();
            CreateMap<ProductReview, ProductReviewResource>();
            CreateMap<ReviewFormModel, ProductReview>();
            CreateMap<ProductReview, ReviewFormModel>();
        }
    }
}
