using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_Network.Data;
using Social_Network.Models;

namespace Social_Network.Controllers
{
    public class NewsfeedsController : Controller
    {
        private readonly AppDbContext _context;

        public NewsfeedsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Newsfeeds
        public async Task<IActionResult> Index()
        {
              return _context.Newsfeed != null ? 
                          View(await _context.Newsfeed.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Newsfeed'  is null.");
        }

        // GET: Newsfeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Newsfeed == null)
            {
                return NotFound();
            }

            var newsfeed = await _context.Newsfeed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsfeed == null)
            {
                return NotFound();
            }

            return View(newsfeed);
        }

        // GET: Newsfeeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newsfeeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorName,Message")] Newsfeed newsfeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsfeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsfeed);
        }

        // GET: Newsfeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Newsfeed == null)
            {
                return NotFound();
            }

            var newsfeed = await _context.Newsfeed.FindAsync(id);
            if (newsfeed == null)
            {
                return NotFound();
            }
            return View(newsfeed);
        }

        // POST: Newsfeeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuthorName,Message")] Newsfeed newsfeed)
        {
            if (id != newsfeed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsfeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsfeedExists(newsfeed.Id))
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
            return View(newsfeed);
        }

        // GET: Newsfeeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Newsfeed == null)
            {
                return NotFound();
            }

            var newsfeed = await _context.Newsfeed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsfeed == null)
            {
                return NotFound();
            }

            return View(newsfeed);
        }

        // POST: Newsfeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Newsfeed == null)
            {
                return Problem("Entity set 'AppDbContext.Newsfeed'  is null.");
            }
            var newsfeed = await _context.Newsfeed.FindAsync(id);
            if (newsfeed != null)
            {
                _context.Newsfeed.Remove(newsfeed);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsfeedExists(int id)
        {
          return (_context.Newsfeed?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
