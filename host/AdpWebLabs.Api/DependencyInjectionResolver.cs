using AdpWebLabs.Domain.Services;
using AdpWebLabs.Domain.Services.Interfaces;

namespace AdpWebLabs.Api
{
    public static class DependencyInjectionResolver
    {
        public static void InjectServices(this IServiceCollection collection)
        {
            collection.AddScoped<ITaskService, TaskService>();

            collection.AddScoped<ICalculationService, CalculationService>();
        }
    }
}
