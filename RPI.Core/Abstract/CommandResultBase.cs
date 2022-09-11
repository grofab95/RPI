using System;

namespace RPI.Core.Abstract;

public abstract class CommandResultBase : IMessage
{
    public Guid Id { get; }
    public Exception Error { get; }
    
    public bool IsSuccess => Error == null;
    public bool IsFailure => Error != null;

    protected CommandResultBase(Guid id, Exception error)
    {
        Id = id;
        Error = error;
    }
    
    protected CommandResultBase(Guid id)
    {
        Id = id;
    }
}