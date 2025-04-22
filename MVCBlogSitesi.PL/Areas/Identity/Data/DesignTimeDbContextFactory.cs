using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MVCBlogSitesiProjesi.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MVCBlogSitesiPLContext>
    {
        public MVCBlogSitesiPLContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MVCBlogSitesiPLContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MVCBlogSitesiPLContextConnection"));

            return new MVCBlogSitesiPLContext(optionsBuilder.Options);
        }
    }
}
