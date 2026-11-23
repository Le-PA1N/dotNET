using System.ComponentModel.DataAnnotations;

namespace VolchukRazorGames.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int HourCount { get; set; }
        [DataType(DataType.Date)] // Можна буде поміняти якщо захочеться додати іфнормацію про час, а не тільки дату //
        public DateTime LastPlayed { get; set; }
        public int AchievementsEarned { get; set; }
        public int AchievementsTotal { get; set; }

    }
}
