﻿using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace Aban360.OldCalcPool.Persistence.Extensions
{
    public static class ConfigureServices
    {
        public static void AddOldCalcPoolPersistenceInjections(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan
                    .FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(publicOnly: false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        }
    }
}
