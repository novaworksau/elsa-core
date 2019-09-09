using System;
using Elsa.AutoMapper.Extensions;
using Elsa.Persistence.YesSql.Indexes;
using Elsa.Persistence.YesSql.Mapping;
using Elsa.Persistence.YesSql.Services;
using Elsa.Persistence.YesSql.StartupTasks;
using Elsa.Runtime;
using Microsoft.Extensions.DependencyInjection;
using YesSql;
using YesSql.Indexes;

namespace Elsa.Persistence.YesSql.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddYesSql(this IServiceCollection services, Action<IConfiguration> configure)
        {
            return services
                .AddSingleton(sp => StoreFactory.CreateStore(sp, configure))
                .AddScoped(CreateSession)
                .AddStartupTask<StoreInitializationTask>();
        }

        public static IServiceCollection AddYesSqlWorkflowInstanceStore(this IServiceCollection services)
        {
            return services
                .AddSingleton<IIndexProvider, WorkflowInstanceIndexProvider>()
                .AddAutoMapperProfile<DocumentProfile>(ServiceLifetime.Singleton)
                .AddScoped<IWorkflowInstanceStore, YesSqlWorkflowInstanceStore>();
        }

        public static IServiceCollection AddYesSqlWorkflowDefinitionStore(this IServiceCollection services)
        {
            return services
                .AddSingleton<IIndexProvider, WorkflowDefinitionIndexProvider>()
                .AddAutoMapperProfile<DocumentProfile>(ServiceLifetime.Singleton)
                .AddScoped<IWorkflowDefinitionStore, YesSqlWorkflowDefinitionStore>();
        }

        private static ISession CreateSession(IServiceProvider services)
        {
            var store = services.GetRequiredService<IStore>();
            return store.CreateSession();
        }
    }
}