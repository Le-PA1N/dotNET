using Microsoft.EntityFrameworkCore;

public class VolchukRazorGamesContext(DbContextOptions<VolchukRazorGamesContext> options) : DbContext(options)
{
    public DbSet<VolchukRazorGames.Models.Game> Game { get; set; } = default!;
}
