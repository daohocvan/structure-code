using Structure.Contract.Abstractions.Message;

namespace Structure.Application.UseCases.V1.Commands.Product
{
    public class CreateProductCommand : ICommand
    {
        public string Name { get; set; }
    }
}
