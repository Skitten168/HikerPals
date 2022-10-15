using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HikerPals.Models;

namespace HikerPals.Controllers
{
    public class TrailsController : Controller
    {
        private readonly HikerContext _context;

        public TrailsController(HikerContext context)
        {
            _context = context;
        }

        // GET: Trails
        public async Task<IActionResult> Index()
        {
            var hikerContext = _context.Trails.Include(t => t.Hiker);
            return View(await hikerContext.ToListAsync());
        }

        // GET: Trails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails
                .Include(t => t.Hiker)
                .FirstOrDefaultAsync(m => m.TrailId == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // GET: Trails/Create
        public IActionResult Create()
        {
            ViewData["HikerId"] = new SelectList(_context.Hikers, "Id", "TrailName");
            return View();
        }

        // POST: Trails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrailId,TName,Distance,HikerId")] Trail trail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HikerId"] = new SelectList(_context.Hikers, "Id", "TrailName", trail.HikerId);
            return View(trail);
        }

        // GET: Trails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails.FindAsync(id);
            if (trail == null)
            {
                return NotFound();
            }
            ViewData["HikerId"] = new SelectList(_context.Hikers, "Id", "TrailName", trail.HikerId);
            return View(trail);
        }

        // POST: Trails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrailId,TName,Distance,HikerId")] Trail trail)
        {
            if (id != trail.TrailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailExists(trail.TrailId))
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
            ViewData["HikerId"] = new SelectList(_context.Hikers, "Id", "TrailName", trail.HikerId);
            return View(trail);
        }

        // GET: Trails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails
                .Include(t => t.Hiker)
                .FirstOrDefaultAsync(m => m.TrailId == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // POST: Trails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trail = await _context.Trails.FindAsync(id);
            _context.Trails.Remove(trail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrailExists(int id)
        {
            return _context.Trails.Any(e => e.TrailId == id);
        }
    }
}
