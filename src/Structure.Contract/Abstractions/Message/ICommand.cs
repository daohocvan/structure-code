using MediatR;
using Structure.Contract.Abstractions.Shared;

namespace Structure.Contract.Abstractions.Message
{
    public interface ICommand : IRequest<Result>
    {

    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
