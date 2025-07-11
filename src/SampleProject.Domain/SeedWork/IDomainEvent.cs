using System;
using Cortex.Mediator;

namespace SampleProject.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}