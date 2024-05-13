using Application.Interfaces;
using Domain.Dtos;
using MediatR;

namespace Application.Product.Commands.Delete
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, ResultWithId>
    {
        private readonly IProductRepository repository;

        public DeleteProductRequestHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResultWithId> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var item = await repository.GetByIdAsync(request.Id);

            // verify that record exists
            if (item == null)
            {
                return new ResultWithId
                {
                    Succeed = false,
                    Errors = new Dictionary<string, string[]> { { "404", new string[] { "item not found." } } },
                    Id = request.Id
                };
            }

            // remove from database
            await repository.DeleteAsync(item);

            // return value
            return new ResultWithId { Id = request.Id, Succeed = true };
        }
    }
}
