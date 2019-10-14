using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS.Data;
using LMS.Models;

namespace LMS.Controllers
{
    public class CheckoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Checkouts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Checkout.Include(c => c.Book)
                .Include(c => c.Patron);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Checkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout
                .Include(c => c.Book)
                .Include(c => c.Patron)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // GET: Checkouts/Create
        public IActionResult Create(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var book = _context.Book.Find(id);
            //if (book == null)
            //{
            //    return NotFound();
            //}

            //var checkout = new Checkout { BookID = book.ID, BorrowDate = DateTime.Today, Book = book };
            //ViewData["PatronID"] = new SelectList(_context.Patron, "ID", "FullName");
            //ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            //return View(checkout);

            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            ViewData["PatronID"] = new SelectList(_context.Patron, "ID", "FullName");
            return View();
        }

        // POST: Checkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BookID,PatronID,BorrowDate,ReturnDate")] Checkout checkout)
        {
            //if (ModelState.IsValid)
            //{
            //    
            //    _context.Checkout.Add(checkout);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index", "Books");
            //}

            //ViewData["PatronID"] = new SelectList(_context.Patron, "ID", "FullName", checkout.PatronID);
            //checkout.Book = _context.Book.Find(checkout.BookID);
            //return View(checkout);

            if (ModelState.IsValid)
            {
                checkout.ReturnDate = checkout.BorrowDate.AddDays(14);
                _context.Add(checkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title", checkout.BookID);
            ViewData["PatronID"] = new SelectList(_context.Patron, "ID", "FullName", checkout.PatronID);
            return View(checkout);
        }

        // GET: Checkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout.FindAsync(id);
            if (checkout == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title", checkout.BookID);
            ViewData["PatronID"] = new SelectList(_context.Patron, "ID", "FullName", checkout.PatronID);
            return View(checkout);
        }

        // POST: Checkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BookID,PatronID,BorrowDate,ReturnDate")] Checkout checkout)
        {
            if (id != checkout.ID)
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
                    if (!CheckoutExists(checkout.ID))
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
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title", checkout.BookID);
            ViewData["PatronID"] = new SelectList(_context.Patron, "ID", "FullName", checkout.PatronID);
            return View(checkout);
        }

        // GET: Checkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout
                .Include(c => c.Book)
                .Include(c => c.Patron)
                .FirstOrDefaultAsync(m => m.ID == id);
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
            var checkout = await _context.Checkout.FindAsync(id);
            _context.Checkout.Remove(checkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckoutExists(int id)
        {
            return _context.Checkout.Any(e => e.ID == id);
        }
    }
}
