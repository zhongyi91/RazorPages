using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages.Web.Models;

namespace RazorPages.Web.Pages.Movie
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesContext _context;

        public IndexModel(RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Models.Movie> Movie { get;set; }
        public SelectList GenreList { get; set; }
        public string SearchGenre { get; set; }

        public async Task OnGetAsync(string searchGenre, string searchString)
        {
            var movies = await _context.Movie.ToListAsync();
            var predicate = GenerateSearchPredicate(searchGenre, searchString);

            GenreList = await GetGenreList();
            Movie = movies.FindAll(m => predicate(m));
        }

        private Func<Models.Movie, bool> GenerateSearchPredicate(string searchGenre, string searchString)
        {
            bool PredicateTitle(Models.Movie m) => string.IsNullOrEmpty(searchString) || m.Title.ToLower().Contains(searchString.ToLower());
            bool PredicateGenre(Models.Movie m) => string.IsNullOrEmpty(searchGenre) || m.Genre == searchGenre;

            bool FinalPredicate(Models.Movie m) => PredicateTitle(m) && PredicateGenre(m);
            return FinalPredicate;
        }

        private async Task<SelectList> GetGenreList()
        {
            var lstGenre = await _context.Movie.Select(m => m.Genre).Distinct().OrderBy(m => m).ToListAsync();
            return new SelectList(lstGenre);
        }
    }
}
