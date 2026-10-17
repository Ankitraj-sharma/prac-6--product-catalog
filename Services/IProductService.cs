using ProductCatalogApp.Models;

namespace ProductCatalogApp.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        bool DeleteProduct(int id);
        List<string> GetCategories();
        IEnumerable<Product> GetFeaturedProducts(int count = 4);
    }
}
