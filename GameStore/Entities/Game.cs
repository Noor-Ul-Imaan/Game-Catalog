using System;

namespace GameStore.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }

    //both below for fk of genre table
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }

    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
