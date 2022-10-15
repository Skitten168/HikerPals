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
    public class HikerController : Controller
    {
        private readonly HikerContext _context;

        public HikerController(HikerContext context)
        {
            _context = context;
        }

        // GET: Hiker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hikers.ToListAsync());
        }

        // GET: Hiker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiker = await _context.Hikers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hiker == null)
            {
                return NotFound();
            }

            return View(hiker);
        }

        // GET: Hiker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hiker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrailName,Age,AverageDailyMiles,YearsExperience")] Hiker hiker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hiker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hiker);
        }

        // GET: Hiker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiker = await _context.Hikers.FindAsync(id);
            if (hiker == null)
            {
                return NotFound();
            }
            return View(hiker);
        }

        // POST: Hiker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrailName,Age,AverageDailyMiles,YearsExperience")] Hiker hiker)
        {
            if (id != hiker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hiker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HikerExists(hiker.Id))
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
            return View(hiker);
        }

        // GET: Hiker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiker = await _context.Hikers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hiker == null)
            {
                return NotFound();
            }

            return View(hiker);
        }

        // POST: Hiker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hiker = await _context.Hikers.FindAsync(id);
            _context.Hikers.Remove(hiker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HikerExists(int id)
        {
            return _context.Hikers.Any(e => e.Id == id);
        }
    }
}
