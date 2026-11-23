using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VolchukRazorGames.Models;

namespace VolchukRazorGames.Pages.GamePages;

public class EditModel : PageModel
{
    private readonly VolchukRazorGamesContext _context;

    public EditModel(VolchukRazorGamesContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Game Game { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var game = await _context.Game.FirstOrDefaultAsync(m => m.Id == id);
        if (game is null)
        {
            return NotFound();
        }
        Game = game;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Game).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GameExists(Game.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool GameExists(int id)
    {
        return _context.Game.Any(e => e.Id == id);
    }
}
