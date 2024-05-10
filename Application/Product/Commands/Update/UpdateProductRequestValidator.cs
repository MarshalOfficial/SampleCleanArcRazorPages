using FluentValidation;

namespace Application.Product.Commands.Update
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(500).WithMessage("Product name can't be longer than 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.")
                .LessThan(100000).WithMessage("Product price must be less than $100K.");
        }
    }
}