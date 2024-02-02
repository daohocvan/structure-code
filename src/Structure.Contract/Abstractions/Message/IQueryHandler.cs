using MediatR;
using Structure.Contract.Abstractions.Shared;

namespace Structure.Contract.Abstractions.Message
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> 
        where TQuery : IQuery<TResponse>
    {

    }
}
