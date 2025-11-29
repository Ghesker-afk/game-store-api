using System;

namespace GameStore.Api.Entities;

public class Genre
{
  public int Id { get; set; }

  // whenever that a instance of Genre is created, we need
  // to make sure that they provide a value for name with the
  // object constructor.

  // while constructing the object, they MUST pass in a value
  // for the property Name (required)
  public required string Name { get; set; }
}
