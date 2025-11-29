using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

// data anotations -> are attributes that you can apply to 
// your properties and can define what is expected for these 
// properties.

// anywhere we use this DTO, that validation(s) should be
// automatically applied!

// endpoints filters -> it's used to validate what is coming
// to your endpoint and do some validations around it.

// the game's id it's gonna be provided by the server itself, and not by ours

public record class CreateGameDto (
  [Required][StringLength(50)] string Name,
  int GenreId,
  [Range(1, 100)] decimal Price,
  DateOnly ReleaseDate
);
