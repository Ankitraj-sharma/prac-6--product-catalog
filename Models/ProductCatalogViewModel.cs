namespace ProductCatalogApp.Models
{
    public class ProductCatalogViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public string? SearchString { get; set; }
        public string? SelectedCategory { get; set; }
        public string? SortOrder { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public int TotalCount { get; set; }
    }
}
