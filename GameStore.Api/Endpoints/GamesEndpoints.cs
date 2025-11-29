using System;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
  const string GetGameEndpointName = "GetGame";

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
    group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.Include(game => game.Genre).Select(game => game.ToGameSummaryDto()).AsNoTracking().ToListAsync());

    // GET /games/id
    group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
    {
      Game? game = await dbContext.Games.FindAsync(id);

      return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
    })
      .WithName(GetGameEndpointName);

    // POST /games
    group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
    {
      // proper validation -> data anotations

      Game game = newGame.ToEntity();

      dbContext.Games.Add(game);
      await dbContext.SaveChangesAsync();

      return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
    });

    // PUT /games
    group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
    {
      var existingGame = await dbContext.Games.FindAsync(id);

      if (existingGame is null)
      {
        return Results.NotFound();
      }

      dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));

      await dbContext.SaveChangesAsync();

      return Results.NoContent();
    });

    // DELETE /games/1
    group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
    {
      // batch delete -> in one shot is go to straight into
      // database, find the entity and delete it right away
      await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

      return Results.NoContent();
    });
  
  return group;
  }
}
