using System;
using MediatR;

namespace RPI.Core.Abstract;

public abstract record MessageBase
{
    public DateTime Timestamp { get; } = DateTime.Now;

    protected MessageBase()
    {
        
    }
}

public abstract record EventBase() : MessageBase, INotification;