using ProductCatalogApp.Models;

namespace ProductCatalogApp.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        private readonly object _lock = new();

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Ultra-Slim Pro Laptop 15\"",
                    Description = "High performance laptop with 16-core processor, 32GB RAM, 1TB NVMe SSD, and 4K OLED display. Ideal for software engineering, video editing, and multitasking.",
                    Category = "Electronics",
                    Price = 1299.99m,
                    StockQuantity = 18,
                    Rating = 4.8,
                    ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 2,
                    Name = "Active Noise-Cancelling Headphones",
                    Description = "Over-ear wireless headphones with industry-leading active noise cancellation, 30-hour battery life, and crystal-clear microphone audio.",
                    Category = "Electronics",
                    Price = 249.50m,
                    StockQuantity = 45,
                    Rating = 4.9,
                    ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 3,
                    Name = "NextGen Flagship Smartphone 5G",
                    Description = "6.7-inch Super AMOLED 120Hz display, 200MP triple camera system, Snapdragon 8 Gen 3 chipset, and all-day fast wireless charging battery.",
                    Category = "Electronics",
                    Price = 899.00m,
                    StockQuantity = 24,
                    Rating = 4.7,
                    ImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 4,
                    Name = "Classic Leather Bomber Jacket",
                    Description = "Handcrafted genuine lambskin leather jacket with premium quilted lining, durable brass YKK zippers, and timeless urban styling.",
                    Category = "Fashion & Apparel",
                    Price = 189.99m,
                    StockQuantity = 12,
                    Rating = 4.6,
                    ImageUrl = "https://images.unsplash.com/photo-1521223890158-f9f7c3d5d504?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 5,
                    Name = "Lightweight Trail Running Shoes",
                    Description = "Breathable knit mesh upper with responsive foam cushioning and high-traction rubber outsole designed for road and trail runners.",
                    Category = "Fashion & Apparel",
                    Price = 79.99m,
                    StockQuantity = 60,
                    Rating = 4.4,
                    ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 6,
                    Name = "Smart Automatic Espresso Machine",
                    Description = "15-bar Italian pump with integrated conical burr grinder, milk frothing wand, and customizable temperature and shot profiling.",
                    Category = "Home & Kitchen",
                    Price = 429.00m,
                    StockQuantity = 8,
                    Rating = 4.9,
                    ImageUrl = "https://images.unsplash.com/photo-1517668808822-9ebb02f2a0e6?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 7,
                    Name = "Digital Air Fryer & Convection Oven 6Qt",
                    Description = "Rapid air-circulation technology lets you fry, roast, bake, and dehydrate with up to 85% less oil. Touchscreen with 8 presets.",
                    Category = "Home & Kitchen",
                    Price = 119.95m,
                    StockQuantity = 30,
                    Rating = 4.7,
                    ImageUrl = "https://images.unsplash.com/photo-1588854337221-4cf9fa96059c?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 8,
                    Name = "Clean Architecture & Design Guide",
                    Description = "Essential software engineering patterns, modular system architecture, and SOLID principles guide for professional C# and .NET developers.",
                    Category = "Books & Stationery",
                    Price = 44.99m,
                    StockQuantity = 75,
                    Rating = 5.0,
                    ImageUrl = "https://images.unsplash.com/photo-1532012164546-f432f2e3725b?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 9,
                    Name = "Smart Fitness Watch with Heart Sensor",
                    Description = "Waterproof smartwatch with GPS tracking, ECG sensor, SpO2 monitor, sleep analytics, and 7-day battery life.",
                    Category = "Electronics",
                    Price = 159.99m,
                    StockQuantity = 22,
                    Rating = 4.5,
                    ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=600&auto=format&fit=crop&q=80"
                },
                new Product
                {
                    Id = 10,
                    Name = "Ergonomic Mechanical Keyboard RGB",
                    Description = "Hot-swappable mechanical switches, custom sound dampening foam, PBT double-shot keycaps, and customizable per-key RGB backlighting.",
                    Category = "Electronics",
                    Price = 99.00m,
                    StockQuantity = 0, // Test Out of Stock
                    Rating = 4.8,
                    ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=600&auto=format&fit=crop&q=80"
                }
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            lock (_lock)
            {
                return _products.OrderBy(p => p.Id).ToList();
            }
        }

        public Product? GetProductById(int id)
        {
            lock (_lock)
            {
                return _products.FirstOrDefault(p => p.Id == id);
            }
        }

        public void AddProduct(Product product)
        {
            lock (_lock)
            {
                int newId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
                product.Id = newId;

                if (string.IsNullOrWhiteSpace(product.ImageUrl))
                {
                    product.ImageUrl = "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=600&auto=format&fit=crop&q=80";
                }

                _products.Add(product);
            }
        }

        public void UpdateProduct(Product product)
        {
            lock (_lock)
            {
                var existing = _products.FirstOrDefault(p => p.Id == product.Id);
                if (existing != null)
                {
                    existing.Name = product.Name;
                    existing.Description = product.Description;
                    existing.Category = product.Category;
                    existing.Price = product.Price;
                    existing.StockQuantity = product.StockQuantity;
                    existing.Rating = product.Rating;
                    existing.ImageUrl = string.IsNullOrWhiteSpace(product.ImageUrl) ? existing.ImageUrl : product.ImageUrl;
                }
            }
        }

        public bool DeleteProduct(int id)
        {
            lock (_lock)
            {
                var product = _products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    return _products.Remove(product);
                }
                return false;
            }
        }

        public List<string> GetCategories()
        {
            lock (_lock)
            {
                return _products
                    .Select(p => p.Category)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();
            }
        }

        public IEnumerable<Product> GetFeaturedProducts(int count = 4)
        {
            lock (_lock)
            {
                return _products
                    .Where(p => p.IsAvailable)
                    .OrderByDescending(p => p.Rating)
                    .Take(count)
                    .ToList();
            }
        }
    }
}
