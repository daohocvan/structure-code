using Structure.Contract.Abstractions.Message;

namespace Structure.Contract.Services.Product
{
    public static class Command
    {
        public record CreateProduct(string name, decimal price, string description) : ICommand;

        public record UpdateProduct(Guid id, string name, decimal price, string description) : ICommand;
        public record DeleteProduct(Guid id) : ICommand;
    }
}