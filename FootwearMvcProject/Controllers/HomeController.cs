using BusinessLogicLayer.Abstract;
using FootwearMvcProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FootwearMvcProject.Controllers
{
    public class HomeController(IProductService productService, ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IProductService _productService = productService;

       
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

    }
}
