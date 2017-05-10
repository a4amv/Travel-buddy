using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddyDatabase
{
    public class MigrationManager : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var connectionString = options.EnvironmentName == "Production"
                ? "Server=tcp:a4amv2.database.windows.net,1433;Initial Catalog=A4AMV;Persist Security Info=False;User ID=JUR;Password=SuperTajneHeslo1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                : "Server=(localdb)\\mssqllocaldb;Database=travelBuddy;Trusted_Connection=True;MultipleActiveResultSets=true;";

            var factory = new ApplicationDbContextFactory(connectionString);
            return factory.Create();
        }
    }
}
