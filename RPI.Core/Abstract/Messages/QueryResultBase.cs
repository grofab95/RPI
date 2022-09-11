using System;

namespace RPI.Core.Abstract.Messages;

public abstract class QueryResultBase<T> : IMessage, IQueryResult
{
    public Guid Id { get; }
    public Exception Error { get; }
    
    public T Value { get; }
    
    public bool IsSuccess => Error == null;
    public bool IsFailure => Error != null;

    protected QueryResultBase(Guid id, Exception error)
    {
        Id = id;
        Error = error;
    }
    
    protected QueryResultBase(Guid id, T value)
    {
        Id = id;
        Value = value;
    }
}