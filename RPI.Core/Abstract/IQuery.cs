using MediatR;

namespace RPI.Core.Abstract;

public interface IQuery : IMessage, IRequest
{
    
}

public interface IQuery<out TResult> : IMessage, IRequest<TResult>
{
}