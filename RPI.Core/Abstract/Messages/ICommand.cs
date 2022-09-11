using MediatR;

namespace RPI.Core.Abstract.Messages;

// public interface ICommand : IMessage, IRequest
// {
//     
// }

public interface ICommand<out TResult> : IMessage, IRequest<TResult>
{
}