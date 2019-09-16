using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group4LMS.Models;

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

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
