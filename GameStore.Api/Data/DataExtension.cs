using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// it's static because is going to be an extension method
public static class DataExtension
{
  public static void MigrateDb(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    dbContext.Database.Migrate();
  }
}
