using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using RoutePlanning.Infrastructure.Database;
using Netcompany.Net.DomainDrivenDesign;
using Netcompany.Net.UnitOfWork;
using Netcompany.Net.UnitOfWork.AmbientTransactions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace RoutePlanning.Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRoutePlanningInfrastructure(this IServiceCollection services)
    {
        var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
        keepAliveConnection.Open();
        services.AddDbContext<RoutePlanningDatabaseContext>(builder =>
        {
            builder.UseSqlite(keepAliveConnection);
            //builder.UseSqlServer("Server=tcp:dbs-oa-dk3.database.windows.net,1433;Initial Catalog=db-oa-dk3;Persist Security Info=False;User ID=admin-oa-dk3;Password=oceanicFlyAway16;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            builder.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
        });

        services.AddDomainDrivenDesign(options => options.UseDbContext<RoutePlanningDatabaseContext>());
        services.AddUnitOfWork(builder => builder.UseAmbientTransactions(x => x.For<RoutePlanningDatabaseContext>()));

        return services;
    }
}
