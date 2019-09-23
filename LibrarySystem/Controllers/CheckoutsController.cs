using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    public class CheckoutsController : Controller
    {
        private readonly LibraryContext _context;

        public CheckoutsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Checkouts
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Checkouts.Include(c => c.Books).Include(c => c.Members);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Checkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkouts
                .Include(c => c.Books)
                .Include(c => c.Members)
                .FirstOrDefaultAsync(m => m.CheckoutID == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // GET: Checkouts/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "Title");
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "FullName");
            return View();
        }

        // POST: Checkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckoutID,MemberID,BookID,CheckoutDate,ReturnDate,DateReturned")] Checkout checkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", checkout.BookID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "MemberID", checkout.MemberID);
            return View(checkout);
        }

        // GET: Checkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkouts.FindAsync(id);
            if (checkout == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", checkout.BookID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "BookID", checkout.MemberID);
            return View(checkout);
        }

        // POST: Checkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckoutID,MemberID,BookID,CheckoutDate,ReturnDate,DateReturned")] Checkout checkout)
        {
            if (id != checkout.CheckoutID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckoutExists(checkout.CheckoutID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID", checkout.BookID);
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "MemberID", checkout.MemberID);
            return View(checkout);
        }

        // GET: Checkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkouts
                .Include(c => c.Books)
                .Include(c => c.Members)
                .FirstOrDefaultAsync(m => m.CheckoutID == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // POST: Checkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkout = await _context.Checkouts.FindAsync(id);
            _context.Checkouts.Remove(checkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckoutExists(int id)
        {
            return _context.Checkouts.Any(e => e.CheckoutID == id);
        }
    }
}
