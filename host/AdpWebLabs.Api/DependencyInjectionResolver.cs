using AdpWebLabs.Domain.Infra.Data.Repository.Interfaces;
using AdpWebLabs.Domain.Infra.Data.Repository;
using AdpWebLabs.Domain.Infra.Data;
using AdpWebLabs.Domain.Services;
using AdpWebLabs.Domain.Services.Interfaces;

namespace AdpWebLabs.Api
{
    public static class DependencyInjectionResolver
    {
        public static void InjectDependencies(this IServiceCollection collection)
        {
            collection.AddScoped<AdpWebLabsContext, AdpWebLabsContext>();
            collection.AddScoped<ITaskContext, TaskContext>();

            InjectServices(collection);
            InjectRepositories(collection);
        }

        private static void InjectServices(this IServiceCollection collection)
        {
            collection.AddScoped<ITaskService, TaskService>();
        }

        private static void InjectRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<ICalculatorRepository, CalculatorRepository>();
        }
    }
}
