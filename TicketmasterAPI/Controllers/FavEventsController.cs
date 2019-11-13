using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TicketmasterAPI.Models
{
    public class FavEventsController : Controller
    {
        private readonly DBModelContext _context;

        public FavEventsController(DBModelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> addFavorite(string name, string url, string city, string state, 
            string genreName, string date)
        {
            FavEvents e = new FavEvents
            {
                City = city,
                Name = name,
                Date = date,
                GenreName = genreName,
                State = state,
                Url = url
            };
            if (ModelState.IsValid)
            {
                _context.Add(e);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(e);

        }

        // GET: FavEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: FavEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favEvents = await _context.Events
                .FirstOrDefaultAsync(m => m.DbId == id);
            if (favEvents == null)
            {
                return NotFound();
            }

            return View(favEvents);
        }

        // GET: FavEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DbId,Name,Url,Date,GenreName,City,State")] FavEvents favEvents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favEvents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favEvents);
        }

        // GET: FavEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favEvents = await _context.Events.FindAsync(id);
            if (favEvents == null)
            {
                return NotFound();
            }
            return View(favEvents);
        }

        // POST: FavEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DbId,Name,Url,Date,GenreName,City,State")] FavEvents favEvents)
        {
            if (id != favEvents.DbId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favEvents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavEventsExists(favEvents.DbId))
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
            return View(favEvents);
        }

        // GET: FavEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favEvents = await _context.Events
                .FirstOrDefaultAsync(m => m.DbId == id);
            if (favEvents == null)
            {
                return NotFound();
            }

            return View(favEvents);
        }

        // POST: FavEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favEvents = await _context.Events.FindAsync(id);
            _context.Events.Remove(favEvents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavEventsExists(int id)
        {
            return _context.Events.Any(e => e.DbId == id);
        }
    }
}
