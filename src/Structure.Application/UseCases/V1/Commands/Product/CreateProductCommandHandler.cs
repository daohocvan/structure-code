using Structure.Contract.Abstractions.Message;
using Structure.Contract.Abstractions.Shared;

namespace Structure.Application.UseCases.V1.Commands.Product
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        public Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
