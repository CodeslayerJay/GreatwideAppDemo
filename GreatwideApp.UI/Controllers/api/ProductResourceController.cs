using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GreatwideApp.Domain.Interfaces.Services;
using GreatwideApp.UI.Models.ApiResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GreatwideApp.UI.Controllers.api
{
    [Route("api/products")]
    [ApiController]
    public class ProductResourceController : ControllerBase
    {
        private readonly IProductService _productService;

        public IMapper _mapper { get; }

        private readonly ILogger<ProductResourceController> _logger;

        public ProductResourceController(IProductService productService, IMapper mapper, 
            ILogger<ProductResourceController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productService.GetProducts().Select(x => _mapper.Map<ProductResource>(x));
                return Ok(products);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"An error occurred during request GetProducts/ProductResourceController. {ex.Message}");
                return BadRequest();
            }
        }
    }
}