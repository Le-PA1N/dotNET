using Microsoft.EntityFrameworkCore;
using VolchukRazorGames;

namespace VolchukRazorGames.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VolchukRazorGamesContext(serviceProvider.GetRequiredService<DbContextOptions<VolchukRazorGamesContext>>()))
            {
                if (context == null || context.Game == null)
                {
                    throw new ArgumentNullException();
                }

                if (context.Game.Any())
                {
                    return;
                }

                context.Game.AddRange(
                    new Game
                    {
                        Title = "Tike",
                        HourCount = 111,
                        LastPlayed = DateTime.Parse("1999-2-12"),
                        AchievementsTotal = 111,
                        AchievementsEarned = 111,
                        Price = 0.01
                       
                    },
                    new Game
                    {
                        Title = "Tike1",
                        HourCount = 2,
                        LastPlayed = DateTime.Parse("1999-2-12"),
                        AchievementsTotal = 100000,
                        AchievementsEarned = 1,
                        Price = 0.01
                    },
                    new Game
                    {
                        Title = "Michael jackson",
                        HourCount = 61,
                        LastPlayed = DateTime.Parse("1999-2-12"),
                        AchievementsTotal = 135,
                        AchievementsEarned = 67,
                        Price = 0.01

                    },
                    new Game
                    {
                        Title = "TABG",
                        HourCount = 666,
                        LastPlayed = DateTime.Parse("1999-2-12"),
                        AchievementsTotal = 1,
                        AchievementsEarned = 0,
                        Price = 0.01

                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
