using FluentValidation;

namespace Structure.Contract.Services.Product.Validators
{
    public class UpdateProductValidator : AbstractValidator<Command.UpdateProduct>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.name).NotEmpty();
            RuleFor(x => x.price).GreaterThan(0);
        }
    }
}