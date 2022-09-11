using MediatR;

namespace RPI.Core.Abstract.Messages;

public interface IQueryHandler<in TQuery, TQueryResult> :
    IRequestHandler<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{

}