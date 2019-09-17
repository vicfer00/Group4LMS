using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group4LMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Group4LMS.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Group4LMS.Models.Group4LMSContext _context;

        public IndexModel(Group4LMS.Models.Group4LMSContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Book
                                            orderby m.Genre
                                            select m.Genre;

            var books = from b in _context.Book
                         select b;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookGenre))
            {
                books = books.Where(x => x.Genre == BookGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
