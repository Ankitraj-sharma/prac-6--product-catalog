using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogApp.Models;
using ProductCatalogApp.Services;

namespace ProductCatalogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductService productService, ILogger<HomeController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var allProducts = _productService.GetAllProducts().ToList();

            var viewModel = new HomeDashboardViewModel
            {
                TotalProducts = allProducts.Count,
                TotalCategories = _productService.GetCategories().Count,
                TotalInStock = allProducts.Count(p => p.IsAvailable),
                FeaturedProducts = _productService.GetFeaturedProducts(4)
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
