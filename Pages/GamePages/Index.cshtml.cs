using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
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

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }
    [BindProperty(SupportsGet = true)]
    public bool? ReverseHourSort { set; get; } = false;
    public SelectList? Titles { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? GameTitle { get; set; }
    public async Task OnGetAsync()
    {


        var games = from g in _context.Game select g;

        if (!string.IsNullOrEmpty(SearchString))
        {
            games = games.Where(s => s.Title.Contains(SearchString));
        }

        if (ReverseHourSort.Equals(true))
        {
            games = games.OrderByDescending(s => s.HourCount);
        }
        else
        {
            games = games.OrderBy(s => s.HourCount);
        }

        Game = await games.ToListAsync();
    }
}
