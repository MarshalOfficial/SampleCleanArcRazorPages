using MediatR;

namespace Application.Product.Commands.Create
{
    public class CreateProductRequest : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}