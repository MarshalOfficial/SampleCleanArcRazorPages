using Application.Product.Commands._Share;
using Domain.Dtos;
using MediatR;

namespace Application.Product.Commands.Create
{
    public class CreateProductRequest : BaseProductRequest, IRequest<ResultWithId>
    {
    }
}