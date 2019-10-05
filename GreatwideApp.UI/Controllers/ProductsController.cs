using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GreatwideApp.Domain.Entities;
using GreatwideApp.Domain.Exceptions;
using GreatwideApp.Domain.Interfaces.Services;
using GreatwideApp.UI.Models;
using GreatwideApp.UI.Models.Validators;
using GreatwideApp.UI.Models.ViewModels;
using GreatwideApp.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Index(int size = 15, int skip = 1)
        {
            try
            {
                var products = _productService.GetProducts(skip, size)
                                    .Select(x => _mapper.Map<ProductViewModel>(x));
                var viewModel = new ProductIndexViewModel
                {
                    Products = products,
                    Pagination = new Pagination(products.Count(), size, skip)
                };

                return View(viewModel);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Something occured while processing request on Products/Index: {ex.Message}");

                // Display a friendly message
                TempData["ErrorMessage"] = AppStrings.GenericErrorMsg;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet("Edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            try
            {
                var viewModel = new ProductFormModel();

                if (id.HasValue)
                {
                    var product = _productService.GetProduct(id.Value);

                    if (product == null)
                    {
                        TempData["InfoMessage"] = "Product not found.";
                        return RedirectToAction(nameof(Index));
                    }

                    viewModel = _mapper.Map<ProductFormModel>(product);
                }

                viewModel.ProductModelSelectItems = _productService.GetAllProductModels()
                        .Select(x => new SelectListItem { Value = x.ProductModelId.ToString(), Text = x.Name });

                return View("ProductForm", viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);

                TempData["ErrorMessge"] = AppStrings.GenericErrorMsg;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ProductFormModel formModel)
        {
            var _validator = new ProductValidator(_productService);
            var results = _validator.Validate(formModel);

            if (results.Errors.Any())
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    var product = (formModel.ProductId == AppStrings.NotSet) ?
                        // Map form model to new entity
                            _mapper.Map<Product>(formModel) :
                        // Map form model to existing entity
                            _mapper.Map<ProductFormModel, Product>(formModel, _productService.GetProduct(formModel.ProductId));
                    
                    _productService.SaveProduct(product);
                    
                    TempData["SuccessMessage"] = AppStrings.ProductEditSuccessMessage;
                    //return RedirectToAction(nameof(Details), new { id = vehicle.Id });
                    return RedirectToAction(nameof(Index));
                }
                catch (ProductSpecException ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Error attempting to save product", ex.Message);
                    TempData["ErrorMessage"] = AppStrings.GenericErrorMsg;
                }
            }

            formModel.ProductModelSelectItems = _productService.GetAllProductModels()
                        .Select(x => new SelectListItem { Value = x.ProductModelId.ToString(), Text = x.Name });
            return View("ProductForm", formModel);
        }
    }
}