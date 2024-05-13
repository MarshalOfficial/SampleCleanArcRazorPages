using Application.Interfaces;
using AutoMapper;
using Domain.Dtos;
using MediatR;

namespace Application.Product.Commands.Create
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, ResultWithId>
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public CreateProductRequestHandler(IProductRepository productRepository, IMapper mapper = null)
        {
            this.repository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ResultWithId> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            // validating incoming data
            var validator = new CreateProductRequestValidator(mapper, repository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid == false)
            {
                return new ResultWithId
                {
                    Succeed = false,
                    Errors = validationResult.ToDictionary(),
                };
            }

            // convert to domain entity data
            var itemToAdd = mapper.Map<Domain.Entities.Product>(request);

            // add to database
            await repository.CreateAsync(itemToAdd);

            // return value
            return new ResultWithId { Id = itemToAdd.Id, Succeed = true };
        }
    }
}
