using AutoMapper;
using GreatwideApp.Domain.Entities;
using GreatwideApp.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product Mappings
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductFormModel>();
            CreateMap<ProductFormModel, Product>();

            // Product Model Mappings
            CreateMap<ProductModel, ProductModelViewModel>();

            // Product Review Mappings
            CreateMap<ProductReview, ProductReviewViewModel>();
        }
    }
}
