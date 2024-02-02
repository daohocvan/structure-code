using Structure.Contract.Abstractions.Message;
using Structure.Contract.Abstractions.Shared;

namespace Structure.Application.UseCases.V1.Queries.Product
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductResponse>
    {
        public Task<Result<GetProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
