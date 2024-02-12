using CQRS.Domain.Repositories;
using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CQRS.CrossCutting.AppDependecies;

public static class DependecyInjection
{
    public static IServiceCollection AddAppDependecies(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });


        // services.AddScoped<IDbConnection>(e => new SqlConnection(connectionString));
        // Registrar IDbConnection como uma instancia unica        
        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        });

        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

        var myHandlers = AppDomain.CurrentDomain.Load("CQRS.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));


        return services;

    }
}
