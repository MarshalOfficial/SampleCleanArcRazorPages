using Application.Product.Commands._Share;
using MediatR;

namespace Application.Product.Commands.Create
{
    public class CreateProductRequest : BaseProductRequest, IRequest<int>
    {
    }
}