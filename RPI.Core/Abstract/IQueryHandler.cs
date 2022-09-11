using System.Threading.Tasks;
using MediatR;

namespace RPI.Core.Abstract;

public interface IQueryHandler<in TQuery, TQueryResult> :
    IRequestHandler<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{

}