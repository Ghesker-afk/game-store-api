using System;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// DBContext is an object that represents a session with
// the database and can be used to query and save instances
// of your entities (is the intermediary).
public class GameStoreContext(DbContextOptions<GameStoreContext> options)
  : DbContext(options)
{
  public DbSet<Game> Games => Set<Game>();

  public DbSet<Genre> Genres => Set<Genre>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Genre>().HasData(
      new { Id = 1, Name = "Fighting" },
      new { Id = 2, Name = "Roleplaying" },
      new { Id = 3, Name = "Sports" },
      new { Id = 4, Name = "Racing" },
      new { Id = 5, Name = "Kids and Family" }
    );
  }
}
