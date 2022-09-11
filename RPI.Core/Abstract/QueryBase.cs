using System;

namespace RPI.Core.Abstract;

public class QueryBase<T, TResult> : IQuery<TResult> where TResult : IQueryResult
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public T Value { get; }

    protected QueryBase(T value)
    {
        Value = value;
    }
}