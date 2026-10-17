using System.ComponentModel.DataAnnotations;

namespace ProductCatalogApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 1000000.00, ErrorMessage = "Price must be between 0.01 and 1,000,000.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(0, 50000, ErrorMessage = "Stock must be between 0 and 50,000.")]
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }

        [Range(1.0, 5.0, ErrorMessage = "Rating must be between 1.0 and 5.0.")]
        [Display(Name = "Customer Rating")]
        public double Rating { get; set; } = 4.5;

        [Display(Name = "Image URL")]
        [Url(ErrorMessage = "Please enter a valid URL for the image.")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "In Stock")]
        public bool IsAvailable => StockQuantity > 0;
    }
}
