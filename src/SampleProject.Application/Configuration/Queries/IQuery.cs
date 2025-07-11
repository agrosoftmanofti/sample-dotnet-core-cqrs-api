using Cortex.Mediator;

namespace SampleProject.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}