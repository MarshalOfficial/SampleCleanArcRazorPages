using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Product.Commands.Delete
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly IProductRepository repository;

        public DeleteProductRequestHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var item = await repository.GetByIdAsync(request.Id);

            // verify that record exists
            if (item == null)
            {
                throw new NotFoundException(nameof(item), request.Id.ToString());
            }

            // remove from database
            await repository.DeleteAsync(item);

            // return value
            return true;
        }
    }
}
