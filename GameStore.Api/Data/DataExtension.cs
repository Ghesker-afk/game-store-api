using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// it's static because is going to be an extension method
public static class DataExtension
{
  public static async Task MigrateDbAsync(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    await dbContext.Database.MigrateAsync();
  }
}
