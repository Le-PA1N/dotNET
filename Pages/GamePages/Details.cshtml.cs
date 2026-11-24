using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VolchukRazorGames.Models;

namespace VolchukRazorGames.Pages.GamePages;

public class DetailsModel : PageModel
{
    private readonly VolchukRazorGamesContext _context;
    public DetailsModel(VolchukRazorGamesContext context)
    {
        _context = context;
    }

    public Game Game { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {


        if (id == null)
        {
            return RedirectToPage("/GamePages/Create");
        }

        var game = await _context.Game.FirstOrDefaultAsync(m => m.Id == id);
        if (game is null)
        {
            return NotFound();
        }
        else
        {
            Game = game;
        }

        return Page();
    }
}
