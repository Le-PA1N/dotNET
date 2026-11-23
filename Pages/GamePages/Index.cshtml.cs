using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VolchukRazorGames.Models;

namespace VolchukRazorGames.Pages.GamePages;

public class IndexModel : PageModel
{
    private readonly VolchukRazorGamesContext _context;

    public IndexModel(VolchukRazorGamesContext context)
    {
        _context = context;
    }

    public IList<Game> Game { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Game = await _context.Game.ToListAsync();
    }
}
