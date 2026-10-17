using Microsoft.AspNetCore.Mvc;
using ProductCatalogApp.Models;
using ProductCatalogApp.Services;

namespace ProductCatalogApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /Product
        public IActionResult Index(string? searchString, string? category, string? sortOrder)
        {
            var products = _productService.GetAllProducts();

            // Search filter
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var lowerSearch = searchString.Trim().ToLower();
                products = products.Where(p =>
                    p.Name.ToLower().Contains(lowerSearch) ||
                    p.Description.ToLower().Contains(lowerSearch) ||
                    p.Category.ToLower().Contains(lowerSearch));
            }

            // Category filter
            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                products = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            // Sorting
            products = sortOrder switch
            {
                "price_asc" => products.OrderBy(p => p.Price),
                "price_desc" => products.OrderByDescending(p => p.Price),
                "name_asc" => products.OrderBy(p => p.Name),
                "name_desc" => products.OrderByDescending(p => p.Name),
                "rating_desc" => products.OrderByDescending(p => p.Rating),
                _ => products.OrderBy(p => p.Id)
            };

            var viewModel = new ProductCatalogViewModel
            {
                Products = products.ToList(),
                SearchString = searchString,
                SelectedCategory = category,
                SortOrder = sortOrder,
                Categories = _productService.GetCategories(),
                TotalCount = products.Count()
            };

            return View(viewModel);
        }

        // GET: /Product/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _productService.GetCategories();
            return View(new Product
            {
                Rating = 4.5,
                StockQuantity = 10,
                ImageUrl = "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=600&auto=format&fit=crop&q=80"
            });
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                TempData["SuccessMessage"] = $"Product '{product.Name}' was successfully added!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _productService.GetCategories();
            return View(product);
        }

        // GET: /Product/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _productService.GetCategories();
            return View(product);
        }

        // POST: /Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                TempData["SuccessMessage"] = $"Product '{product.Name}' was successfully updated!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _productService.GetCategories();
            return View(product);
        }

        // GET: /Product/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productService.GetProductById(id);
            var productName = product?.Name ?? "Product";

            _productService.DeleteProduct(id);
            TempData["SuccessMessage"] = $"Product '{productName}' was successfully deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
