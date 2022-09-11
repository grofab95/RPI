using System;
using MediatR;

namespace RPI.Core.Abstract.Messages;

public abstract record MessageBase
{
    public DateTime Timestamp { get; } = DateTime.Now;

    protected MessageBase()
    {
        
    }
}

public abstract record EventBase() : MessageBase, INotification;