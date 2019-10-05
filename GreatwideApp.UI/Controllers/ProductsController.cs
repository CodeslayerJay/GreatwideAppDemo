using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GreatwideApp.Domain.Entities;
using GreatwideApp.Domain.Exceptions;
using GreatwideApp.Domain.Interfaces;
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
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IAppLogger<ProductsController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper, IAppLogger<ProductsController> logger)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }


        public IActionResult Index(int size = 15, int page = 1)
        {
            try
            {
                var products = _productService.GetProducts(((page - 1) * size), size)
                                    .Select(x => _mapper.Map<ProductViewModel>(x));
                var viewModel = new ProductIndexViewModel
                {
                    Products = products,
                    Pagination = new Pagination(_productService.GetProductCount(), size, page)
                };

                return View(viewModel);
            }
            catch(Exception ex)
            {
                _logger.LogMessage(ex.Message);
                
                TempData["ErrorMessage"] = AppStrings.GenericErrorMsg;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {

            try
            {
                var product = _mapper.Map<ProductViewModel>(_productService.GetProduct(id));

                if (product == null)
                {
                    TempData["InfoMessage"] = AppStrings.ProductNotFoundMessage;
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new ProductDetailViewModel
                {
                    Product = product,
                    ProductReviews = _productService.GetProductReviews(product.ProductId).Select(x => _mapper.Map<ProductReviewViewModel>(x))
                };

                return View("Details", viewModel);
            }
            catch(Exception ex)
            {
                _logger.LogMessage(ex.Message);

                TempData["ErrorMessage"] = AppStrings.GenericErrorMsg;
                return RedirectToAction("Index", "Home");
            }
           
        }

        [HttpGet("edit/{id?}")]
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
                        TempData["InfoMessage"] = AppStrings.ProductNotFoundMessage;
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
                _logger.LogMessage(ex.Message);

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
                    _logger.LogMessage(ex.Message);
                    TempData["ErrorMessage"] = AppStrings.GenericErrorMsg;
                }
            }

            formModel.ProductModelSelectItems = _productService.GetAllProductModels()
                        .Select(x => new SelectListItem { Value = x.ProductModelId.ToString(), Text = x.Name });
            return View("ProductForm", formModel);
        }

        [HttpGet("{id}/add-comment")]
        public IActionResult AddComment(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);

                if (product == null)
                {
                    TempData["InfoMessage"] = AppStrings.ProductNotFoundMessage;
                    return RedirectToAction(nameof(Index));
                }

                var formModel = new ReviewFormModel
                {
                    Product = _mapper.Map<ProductViewModel>(product)
                };

                return View("ReviewForm", formModel);
            }
            catch(Exception ex)
            {
                _logger.LogMessage(ex.Message);
                TempData["ErrorMessage"] = AppStrings.GenericErrorMsg;

                return RedirectToAction(nameof(Details), new { id });
            }
        }
    }
}