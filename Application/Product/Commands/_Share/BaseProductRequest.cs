using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Product.Commands._Share
{
    public class BaseProductRequest
    {
        [MaxLength(500)]
        public string Name { get; set; }

        [Range(0.00, 100000.00)]
        public decimal Price { get; set; }
    }
}