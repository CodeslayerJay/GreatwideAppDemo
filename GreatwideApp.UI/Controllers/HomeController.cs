using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreatwideApp.UI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using GreatwideApp.Domain.Interfaces.Services;

namespace GreatwideApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
            
        }
        public IActionResult Index()
        {
            var product = _productService.GetProducts(10);
            return Json(product);
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError("Error occurred during request.", exception.Path, exception.Error.Message, exception.Error.StackTrace);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
