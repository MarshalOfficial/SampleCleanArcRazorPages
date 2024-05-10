using Application.Product.Commands._Share;
using MediatR;

namespace Application.Product.Commands.Update
{
    public class UpdateProductRequest : BaseProductRequest, IRequest<int>
    {
        public int Id { get; set; }
    }
}