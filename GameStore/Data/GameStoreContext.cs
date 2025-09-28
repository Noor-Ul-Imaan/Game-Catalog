using System;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    //this call execute when you exeucte the migrations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Horror" },
            new { Id = 2, Name = "Indie" },
            new { Id = 3, Name = "Thriller" },
            new { Id = 4, Name = "Racing" }
            );
    }


}
