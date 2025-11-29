using System;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
  const string GetGameEndpointName = "GetGame";
  private static readonly List<GameDto> games = [
    new (1,
      "Street Fighter II",
      "Fighting",
      19.99M,
      new DateOnly(1992, 7, 15)),
    new (2,
      "Final Fantasy XIV",
      "Roleplaying",
      59.99M,
      new DateOnly(2010, 9, 30)),
    new (3,
      "FIFA 2023",
      "Sports",
      69.99M,
      new DateOnly(2022, 9, 27))
  ];

  public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
  {
    // group builder -> defines common things across all the endpoints, so we don't have to define over and over!

    // all the specific endpoints within this builder will start with the prefix passed in.

    // the appropriate endpoint filters will be applied and 
    // will be recognized by these data annotations specified
    // in the DTO.
    
    var group = app.MapGroup("games")
                .WithParameterValidation();

    // GET /games
    group.MapGet("/", () => games);

    // GET /games/id
    group.MapGet("/{id}", (int id) =>
    {
      GameDto? game = games.Find(game => game.Id == id);

      return game is null ? Results.NotFound() : Results.Ok(game);
    })
      .WithName(GetGameEndpointName);

    // POST /games
    group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
    {
      // proper validation -> data anotations

      Game game = newGame.ToEntity();
      game.Genre = dbContext.Genres.Find(newGame.GenreId);

      dbContext.Games.Add(game);
      dbContext.SaveChanges();

      return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToDto());
    });

    // PUT /games
    group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
    {
      var index = games.FindIndex(game => game.Id == id);

      if (index == -1)
      {
        return Results.NotFound();
      }

      games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
      );

      return Results.NoContent();
    });

    // DELETE /games/1
    group.MapDelete("/{id}", (int id) =>
    {
      games.RemoveAll(game => game.Id == id);

      return Results.NoContent();
    });
  
  return group;
  }
}
