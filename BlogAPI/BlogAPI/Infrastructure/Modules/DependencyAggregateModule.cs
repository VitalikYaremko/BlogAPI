using BlogAPI.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Modules
{
    public class DependencyAggregateModule : IDependencyModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddModule<ServicesModule>();
            services.AddModule<DataModule>();
            services.AddModule<MappingModule>();
        }
    }
}
