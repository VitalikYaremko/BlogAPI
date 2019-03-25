using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.DependencyInjection
{
    public static class DependecyInjectionExtensions
    {
        public static void AddModule<T>(this IServiceCollection services) where T : class, IDependencyModule, new()
        {
            new T().ConfigureServices(services);
        }
    }
}
