using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Web.Models;

namespace RazorPages.Web.Pages.Movie
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesContext _context;

        public DetailsModel(RazorPagesContext context)
        {
            _context = context;
        }

        public Models.Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
