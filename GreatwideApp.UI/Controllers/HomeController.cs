using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreatwideApp.UI.Models;
using Microsoft.AspNetCore.Diagnostics;
using GreatwideApp.Domain.Interfaces.Services;
using AutoMapper;
using GreatwideApp.UI.Models.ViewModels;
using GreatwideApp.UI.Utilities;
using GreatwideApp.Domain.Interfaces;
using System.Data.SqlClient;

namespace GreatwideApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppLogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public HomeController(IProductService productService, IMapper mapper, IAppLogger<HomeController> logger)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
            
        }

        public IActionResult Index()
        {
            try
            {
                var products = _productService.GetProducts(size: 3)
                                .Select(x => _mapper.Map<ProductViewModel>(x));
                return View(products);
            }
            catch(SqlException sqlEx) when (sqlEx.Number is -2)
            {
                // Catch default sql timeout exception if occurs when app is starting up (locally)
                _logger.LogMessage($"SqlTimeout occurred on { DateTime.Now }. Exception: {sqlEx.Message}");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogMessage(ex.Message);
                return RedirectToAction(nameof(Error));
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"An excption error occurred on { DateTime.Now }", exception);
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
