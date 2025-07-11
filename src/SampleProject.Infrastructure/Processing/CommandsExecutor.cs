using System.Threading.Tasks;
using Autofac;
using Cortex.Mediator;
using SampleProject.Application;
using SampleProject.Application.Configuration.Commands;

namespace SampleProject.Infrastructure.Processing
{
    public static class CommandsExecutor
    {
        public static async Task Execute(ICommand command)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.SendAsync(command);
            }
        }

        public static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.SendAsync(command);
            }
        }
    }
}