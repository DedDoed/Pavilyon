using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Interfaces;

namespace Pavilyon.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            var mySqlMajor = int.Parse(configuration["MySqlMajor"]);
            var mySqlMinor = int.Parse(configuration["MySqlMinor"]);
            var mySqlBuild = int.Parse(configuration["MySqlBuild"]);
            var mySqlVersion = new MySqlServerVersion(new Version(mySqlMajor, mySqlMinor, mySqlBuild));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, mySqlVersion, sql => { sql.MigrationsAssembly("Pavilyon.WebApi"); });
            });
            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            return services;
        }
    }
}
