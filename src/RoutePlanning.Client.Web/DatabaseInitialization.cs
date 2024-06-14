using Netcompany.Net.UnitOfWork;
using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Orders;
using RoutePlanning.Domain.Users;
using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Client.Web;

public static class DatabaseInitialization
{
    public static async Task SeedDatabase(WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();

        var context = serviceScope.ServiceProvider.GetRequiredService<RoutePlanningDatabaseContext>();
        await context.Database.EnsureCreatedAsync();

        var unitOfWorkManager = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();
        await using (var unitOfWork = unitOfWorkManager.Initiate())
        {
            await SeedUsers(context);
            await SeedLocationsAndRoutes(context);

            unitOfWork.Commit();
        }
    }

    private static async Task SeedLocationsAndRoutes(RoutePlanningDatabaseContext context)
    {
        var cairo = new Location("CAIRO");
        await context.AddAsync(cairo);

        var omdurman = new Location("OMDURMAN");
        await context.AddAsync(omdurman);

        var tripoli = new Location("TRIPOLI");
        await context.AddAsync(tripoli);

        var darfurr = new Location("DARFUR");
        await context.AddAsync(darfurr);

        var tunis = new Location("TUNIS");
        await context.AddAsync(tunis);

        var tanger = new Location("TANGER");
        await context.AddAsync(tanger);

        var marrakesh = new Location("MARRAKESH");
        await context.AddAsync(marrakesh);

        var sahara = new Location("SAHARA");
        await context.AddAsync(sahara);

        var dakar = new Location("DAKAR");
        await context.AddAsync(dakar);

        var sierraLeone = new Location("SIERRA LEONE");
        await context.AddAsync(sierraLeone);

        var timbuktu = new Location("TIMBUKTU");
        await context.AddAsync(timbuktu);

        var guldKysten = new Location("GULDKYSTEN");
        await context.AddAsync(guldKysten);

        var slaveKusten = new Location("SLAVEKUSTEN");
        await context.AddAsync(slaveKusten);

        var wadai = new Location("WADAI");
        await context.AddAsync(wadai);

        var congo = new Location("CONGO");
        await context.AddAsync(congo);

        var luanda = new Location("LUANDA");
        await context.AddAsync(luanda);

        var kabalo = new Location("KABALO");
        await context.AddAsync(kabalo);

        var mocambique = new Location("MOCAMBIQUE");
        await context.AddAsync(mocambique);

        var drageBjerget = new Location("DRAGEBJERGET");
        await context.AddAsync(drageBjerget);

        var victoriaFalden = new Location("VICTORIAFALDEN");
        await context.AddAsync(victoriaFalden);

        var hvalBugten = new Location("HVALBUGTEN");
        await context.AddAsync(hvalBugten);

        var kapStaden = new Location("KAPSTADEN");
        await context.AddAsync(kapStaden);

        var victoriaSoen = new Location("VICTORIASOEN");
        await context.AddAsync(victoriaSoen);

        var bahrelGhazal = new Location("BAHREL GHAZAL");
        await context.AddAsync(bahrelGhazal);

        var suakin = new Location("SUAKIN");
        await context.AddAsync(suakin);

        var addisAbeba = new Location("ADDIS ABEBA");
        await context.AddAsync(addisAbeba);

        var kapGuardaFui = new Location("KAP GUARDAFUI");
        await context.AddAsync(kapGuardaFui);

        var zanzibar = new Location("ZANZIBAR");
        await context.AddAsync(zanzibar);

        var deKanariskeOer = new Location("DE KANARISKE OER");
        await context.AddAsync(deKanariskeOer);

        var stHelena = new Location("ST HELENA");
        await context.AddAsync(stHelena);

        var kapStMarie = new Location("KAP ST MARIE");
        await context.AddAsync(kapStMarie);

        var tamatave = new Location("TAMATAVE");
        await context.AddAsync(tamatave);

        CreateTwoWayConnection(cairo, tunis, 1500, 200);
        CreateTwoWayConnection(cairo, omdurman, 800, 120);
        CreateTwoWayConnection(omdurman, tripoli, 1600, 220);
        CreateTwoWayConnection(tripoli, tunis, 800, 100);
        CreateTwoWayConnection(tunis, tanger, 2000, 250);
        CreateTwoWayConnection(tanger, marrakesh, 700, 90);
        CreateTwoWayConnection(marrakesh, sahara, 1400, 180);
        CreateTwoWayConnection(sahara, dakar, 1000, 150);
        CreateTwoWayConnection(dakar, sierraLeone, 700, 100);
        CreateTwoWayConnection(sierraLeone, timbuktu, 1200, 160);
        CreateTwoWayConnection(timbuktu, guldKysten, 800, 110);
        CreateTwoWayConnection(guldKysten, slaveKusten, 300, 50);
        CreateTwoWayConnection(slaveKusten, wadai, 900, 130);
        CreateTwoWayConnection(wadai, congo, 1500, 190);
        CreateTwoWayConnection(congo, luanda, 800, 100);
        CreateTwoWayConnection(luanda, kabalo, 1000, 140);
        CreateTwoWayConnection(kabalo, mocambique, 1100, 150);
        CreateTwoWayConnection(mocambique, drageBjerget, 1300, 170);
        CreateTwoWayConnection(drageBjerget, victoriaFalden, 900, 120);
        CreateTwoWayConnection(victoriaFalden, hvalBugten, 1400, 180);
        CreateTwoWayConnection(hvalBugten, kapStaden, 1200, 160);
        CreateTwoWayConnection(kapStaden, victoriaSoen, 1800, 220);
        CreateTwoWayConnection(victoriaSoen, bahrelGhazal, 1500, 200);
        CreateTwoWayConnection(bahrelGhazal, suakin, 1000, 130);
        CreateTwoWayConnection(suakin, addisAbeba, 1100, 150);
        CreateTwoWayConnection(addisAbeba, kapGuardaFui, 1600, 210);
        CreateTwoWayConnection(kapGuardaFui, zanzibar, 1400, 180);
        CreateTwoWayConnection(zanzibar, deKanariskeOer, 1200, 160);
        CreateTwoWayConnection(deKanariskeOer, stHelena, 1700, 220);
        CreateTwoWayConnection(stHelena, kapStMarie, 1800, 230);
        CreateTwoWayConnection(kapStMarie, tamatave, 1300, 170);

        var freightType1 = new FreightType(100, "Weapons");
        await context.AddAsync(freightType1);
    }

    private static async Task SeedUsers(RoutePlanningDatabaseContext context)
    {
        var alice = new User("alice", User.ComputePasswordHash("alice123!"), "al@somemail.dk", "Salesperson");
        await context.AddAsync(alice);

        var bob = new User("bob", User.ComputePasswordHash("!CapableStudentCries25"), "bob@somemail.com", "Manager");
        await context.AddAsync(bob);
    }

    private static void CreateTwoWayConnection(Location locationA, Location locationB, int distance, decimal travelCost)
    {
        locationA.AddConnection(locationB, distance, travelCost);
        locationB.AddConnection(locationA, distance, travelCost);
    }
}
