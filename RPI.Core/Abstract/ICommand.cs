using MediatR;

namespace RPI.Core.Abstract;

// public interface ICommand : IMessage, IRequest
// {
//     
// }

public interface ICommand<out TResult> : IMessage, IRequest<TResult>
{
}