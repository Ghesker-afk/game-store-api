namespace GameStore.Api.Dtos;

// the game's id it's gonna be provided by the server itself, and not by ours

public record class CreateGameDto (
  string Name,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate
);
