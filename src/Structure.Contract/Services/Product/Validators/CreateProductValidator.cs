using FluentValidation;

namespace Structure.Contract.Services.Product.Validators
{
    public class CreateProductValidator : AbstractValidator<Command.CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.name).NotEmpty();
            RuleFor(x => x.price).GreaterThan(0);
        }
    }
}