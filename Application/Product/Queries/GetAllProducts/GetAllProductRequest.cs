using MediatR;

namespace Application.Product.Queries.GetAllProducts
{
    public record GetAllProductsRequest : IRequest<List<ProductDto>>;
}
