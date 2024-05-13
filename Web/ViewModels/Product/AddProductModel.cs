using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Product
{
    public class AddProductModel
    {
        [MaxLength(500)]
        public string Name { get; set; }

        [Range(0.00, 100000.00)]
        public decimal Price { get; set; }
    }
}
