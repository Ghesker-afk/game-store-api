using System;

namespace GameStore.Api.Entities;

public class Game
{
  public int Id { get; set; }

  public required string Name { get; set; }

  // one-to-one relationship between two tables in
  // Entity Core Framework
  public int GenreId { get; set; }

  public Genre? Genre { get; set; }

  public decimal Price { get; set; }

  public DateOnly ReleaseDate { get; set; }
}
