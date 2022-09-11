using System;

namespace RPI.Core.Abstract;

public abstract class CommandBase<T> : ICommand<T>
{
    public Guid Id { get; } = Guid.NewGuid();
}