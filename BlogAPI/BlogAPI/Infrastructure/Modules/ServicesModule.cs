using BlogAPI.Domain.Interfaces.Repositeries;
using BlogAPI.Domain.Interfaces.Services;
using BlogAPI.Domain.Repositories;
using BlogAPI.Domain.Services;
using BlogAPI.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Modules
{
    public class ServicesModule : IDependencyModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogService>();
        }
    }
}
