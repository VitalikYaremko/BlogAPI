using BlogAPI.Data.Context;
using BlogAPI.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Modules
{
    public class DataModule : IDependencyModule
    {
        public static IConfiguration Configuration { get; set; }

        public DataModule()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDesignTimeDbContextFactory<BlogContext>>(
                x => new BlogContextFactory(Configuration.GetConnectionString("Blog")));
        }
    }
}
