namespace ProductCatalogApp.Models
{
    public class HomeDashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalCategories { get; set; }
        public int TotalInStock { get; set; }
        public IEnumerable<Product> FeaturedProducts { get; set; } = new List<Product>();
    }
}
