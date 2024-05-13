using Domain.Dtos;
using MediatR;

namespace Application.Product.Commands.Delete
{
    public record DeleteProductRequest(int Id) : IRequest<ResultWithId>;
}