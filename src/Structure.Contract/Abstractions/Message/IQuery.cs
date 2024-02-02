using MediatR;
using Structure.Contract.Abstractions.Shared;

namespace Structure.Contract.Abstractions.Message
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
