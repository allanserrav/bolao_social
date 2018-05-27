using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BolaoSocial.Data.EFCoreMigrations
{
    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<EFDataContext>
    {
        EFDataContext IDesignTimeDbContextFactory<EFDataContext>.CreateDbContext(string[] args)
        {
            Console.WriteLine("Using sqlserver");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<EFDataContext>();
            Console.WriteLine($"Sql server: {connectionString}");
            optionsBuilder.UseSqlServer(connectionString);

            return new EFDataContext(optionsBuilder.Options);
        }
    }
}
