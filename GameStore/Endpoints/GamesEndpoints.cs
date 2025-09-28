// using System;

using GameStore.Dtos;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{

    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games =
    [
        new (1, "Elderwood Saga", "RPG", 49.99m, new DateOnly(2023, 10, 15)),
    new (2, "Skybound Racers", "Racing", 39.99m, new DateOnly(2022, 5, 22)),
    new (3, "Galactic Outlaws", "Action", 59.99m, new DateOnly(2024, 2, 10)),
    new (4, "Pixel Farmer", "Simulation", 19.99m, new DateOnly(2021, 11, 3)),
    new (5, "Haunted Horizons", "Horror", 29.99m, new DateOnly(2023, 9, 30)),
    new (6, "CyberChess 2077", "Strategy", 14.99m, new DateOnly(2020, 8, 12)),
    new (7, "Mech Arena X", "Shooter", 44.99m, new DateOnly(2023, 3, 18)),
    new (8, "Mystic Valley", "Adventure", 34.99m, new DateOnly(2022, 6, 5)),
    new (9, "Kingdom Clash", "RTS", 24.99m, new DateOnly(2024, 1, 20)),
    new (10, "Retro Runner", "Platformer", 9.99m, new DateOnly(2019, 12, 25))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games")
        .WithParameterValidation(); //to replace the "games" in all endpoints (http methods url endpoints)

        // GET /games
        group.MapGet("/", () => games);
        //At games root, if a request comes,
        //the handler handles it by returning the games list

        // GET /games/1
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            // if (string.IsNullOrEmpty(newGame.Name))
            // {
            //     return Results.BadRequest("Name is required");
            // }
            //not good way to validate inputs in post method or put cuz more than 1 field (name)
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
                );
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            //above returning something back after done adding, so returned:
            //The route name at which game can be get, the id created for it, and payload
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
