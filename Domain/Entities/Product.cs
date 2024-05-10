using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        [MaxLength(500)]
        public required string Name { get; set; }

        [Range(0.00, 100000.00)]
        public required decimal Price { get; set; }
    }
}