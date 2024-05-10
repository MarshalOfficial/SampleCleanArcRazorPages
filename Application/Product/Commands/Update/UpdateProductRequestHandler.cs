using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Product.Commands.Update
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, int>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;

        public UpdateProductRequestHandler(IMapper mapper, IProductRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<int> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            // validating incoming data
            var validator = new UpdateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Something went wrong", validationResult.ToDictionary());
            }

            // get the item to edit form the DataBase
            var itemToEdit = await repository.GetByIdAsync(request.Id);

            if (itemToEdit is null)
                throw new NotFoundException(nameof(itemToEdit), request.Id.ToString());

            // convert to domain entity data
            mapper.Map(request, itemToEdit);

            // add to database
            await repository.UpdateAsync(itemToEdit);

            // return value
            return itemToEdit.Id;
        }
    }
}
