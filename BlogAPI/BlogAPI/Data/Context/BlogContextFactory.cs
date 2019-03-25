using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Context
{
    public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        private readonly string _connectionString;
        public static IConfiguration Configuration { get; set; }
        public BlogContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public BlogContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionBuilder.UseSqlServer(_connectionString);
            return new BlogContext(optionBuilder.Options);
        }
    }
}
