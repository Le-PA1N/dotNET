using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VolchukRazorGames.Models;

namespace VolchukRazorGames.Pages.GamePages;

public class CreateModel : PageModel
{
    private readonly VolchukRazorGamesContext _context;

    public CreateModel(VolchukRazorGamesContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Game Game { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Game.Add(Game);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
