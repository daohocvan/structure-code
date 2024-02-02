using Structure.Contract.Abstractions.Message;

namespace Structure.Application.UseCases.V1.Queries.Product
{
    public class GetProductQuery : IQuery<GetProductResponse>
    {
        public string Name { get; set; }
    }
}
