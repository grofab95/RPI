using System;

namespace RPI.Core.Abstract;

public interface IMessage
{
    Guid Id { get; }
}