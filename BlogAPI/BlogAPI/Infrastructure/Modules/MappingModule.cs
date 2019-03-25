using AutoMapper;
using BlogAPI.Infrastructure.DependencyInjection;
using BlogAPI.Infrastructure.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Modules
{
    public class MappingModule : IDependencyModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(CreateMapper);
        }

        private static IMapper CreateMapper(IServiceProvider provider)
        {
            var configuration = new MapperConfiguration(AddProfiles);

            return new Mapper(configuration, provider.GetRequiredService);
        }

        private static void AddProfiles(IMapperConfigurationExpression configurationExpression)
        {
            configurationExpression.AddProfile<BlogProfile>(); 
        }
    }
}
