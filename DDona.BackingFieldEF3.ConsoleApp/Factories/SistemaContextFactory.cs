using DDona.BackingFieldEF3.Infra.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.BackingFieldEF3.ConsoleApp.Factories
{
    public class SistemaContextFactory : IDesignTimeDbContextFactory<SistemaContext>
    {
        private const string APP_SETTINGS = "appsettings.json";
        private readonly string _connectionString;

        public SistemaContextFactory()
        {
            var builder = ConfigureBuilder();
            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SistemaContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public SistemaContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<SistemaContext>();
            dbContextBuilder.UseSqlServer(_connectionString);

            return new SistemaContext(dbContextBuilder.Options);
        }

        private ConfigurationBuilder ConfigureBuilder()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(APP_SETTINGS, optional: false);
            return builder;
        }
    }
}
