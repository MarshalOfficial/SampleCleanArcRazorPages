using MediatR;

namespace Application.Product.Queries.GetProductDetails
{
    public record GetProductDetailsRequest(int Id) : IRequest<ProductDetailsDto>;
}