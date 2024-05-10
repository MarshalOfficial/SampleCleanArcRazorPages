using Application.Interfaces;
using AutoMapper;
using FluentValidation;

namespace Application.Product.Commands.Create
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;

        public CreateProductRequestValidator(IMapper mapper, IProductRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(500).WithMessage("Product name can't be longer than 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.")
                .LessThan(100000).WithMessage("Product price must be less than $100K.");

            RuleFor(t => t)
                .MustAsync(UniqueProduct).WithMessage("The product Already exists.");
        }

        private async Task<bool> UniqueProduct(CreateProductRequest request, CancellationToken token)
        {
            var entiry = mapper.Map<Domain.Entities.Product>(request);
            return await repository.IsMemberUnique(entiry);
        }
    }
}