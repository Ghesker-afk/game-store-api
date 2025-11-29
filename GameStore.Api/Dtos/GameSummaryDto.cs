namespace GameStore.Api.Dtos;

// records -> are immutable by default, meaning that once the
// properties are set they can't be changed.

public record class GameSummaryDto (
  int Id,
  string Name,
  string Genre,
  decimal Price,
  DateOnly ReleaseDate
);
