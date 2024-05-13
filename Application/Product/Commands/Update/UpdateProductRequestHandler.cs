using Application.Interfaces;
using AutoMapper;
using Domain.Dtos;
using MediatR;

namespace Application.Product.Commands.Update
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, ResultWithId>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;

        public UpdateProductRequestHandler(IMapper mapper, IProductRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ResultWithId> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            // validating incoming data
            var validator = new UpdateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                return new ResultWithId
                {
                    Succeed = false,
                    Errors = validationResult.ToDictionary(),
                };
            }

            // get the item to edit form the DataBase
            var itemToEdit = await repository.GetByIdAsync(request.Id);

            if (itemToEdit is null)
            {
                return new ResultWithId
                {
                    Succeed = false,
                    Errors = new Dictionary<string, string[]> { { "404", new string[] { "item not found." } } },
                    Id = request.Id
                };
            }


            // convert to domain entity data
            mapper.Map(request, itemToEdit);

            // add to database
            await repository.UpdateAsync(itemToEdit);

            // return value
            return new ResultWithId { Id = itemToEdit.Id, Succeed = true };
        }
    }
}
