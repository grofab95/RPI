using System;

namespace RPI.Core.Abstract.Messages;

public class QueryBase<T, TResult> : IQuery<TResult> where TResult : IQueryResult
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public T Value { get; }

    protected QueryBase(T value)
    {
        Value = value;
    }
}