using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VolchukRazorGames.Models
{
    public class Game
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        [Display(Name = "Hour Count")]
        [Range(0, maximum:uint.MaxValue)]
        public int HourCount { get; set; }
        [DataType(DataType.Date)] // Можна буде поміняти якщо захочеться додати іфнормацію про час, а не тільки дату //
        [Display(Name = "Last Played")]
        public DateTime LastPlayed { get; set; }
        [Display(Name = "Achievements Earned")]
        [Range(0, maximum: uint.MaxValue)]
        public int AchievementsEarned { get; set; }
        [Display(Name = "Achievements Total")]
        [Range(0, maximum: uint.MaxValue)]
        public int AchievementsTotal { get; set; }
        [Range(0, maximum:uint.MaxValue)]
        public double Price { get; set; } = 0d;

    }
}
