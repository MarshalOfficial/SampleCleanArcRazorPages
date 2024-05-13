using Application.Product.Commands._Share;
using Domain.Dtos;
using MediatR;

namespace Application.Product.Commands.Update
{
    public class UpdateProductRequest : BaseProductRequest, IRequest<ResultWithId>
    {
        public int Id { get; set; }
    }
}