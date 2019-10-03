using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GreatwideApp.Domain.Interfaces.Services;
using GreatwideApp.UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GreatwideApp.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }
        public IActionResult Index(int size = 15, int skip = 0)
        {
            try
            {
                var products = _productService.GetProducts(skip, size)
                                    .Select(x => _mapper.Map<ProductViewModel>(x));

                return View(products);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Something occured while processing request on Products/Index: {ex.Message}");

                // Display a friendly message
                TempData["Error"] = "An error occured. Please try again.";
                return RedirectToAction("Index", "Home");
            }
        }

        
    }
}