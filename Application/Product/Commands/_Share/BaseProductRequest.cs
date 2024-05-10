using MediatR;

namespace Application.Product.Commands._Share
{
    public class BaseProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}