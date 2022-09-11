using System;

namespace RPI.Core.Abstract.Messages;

public interface IMessage
{
    Guid Id { get; }
}