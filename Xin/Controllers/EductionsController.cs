using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Xin.Data;
using Xin.Models;

namespace Xin.Controllers
{
    public class EductionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EductionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Eductions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Eduction.Include(e => e.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Eductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eduction = await _context.Eduction
                .Include(e => e.ApplicationUser)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (eduction == null)
            {
                return NotFound();
            }

            return View(eduction);
        }

        // GET: Eductions/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Eductions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SchoolName,Program,StartTime,EndTime,Description,UserId")] Eduction eduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", eduction.UserId);
            return View(eduction);
        }

        // GET: Eductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eduction = await _context.Eduction.SingleOrDefaultAsync(m => m.Id == id);
            if (eduction == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", eduction.UserId);
            return View(eduction);
        }

        // POST: Eductions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SchoolName,Program,StartTime,EndTime,Description,UserId")] Eduction eduction)
        {
            if (id != eduction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EductionExists(eduction.Id))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", eduction.UserId);
            return View(eduction);
        }

        // GET: Eductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eduction = await _context.Eduction
                .Include(e => e.ApplicationUser)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (eduction == null)
            {
                return NotFound();
            }

            return View(eduction);
        }

        // POST: Eductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eduction = await _context.Eduction.SingleOrDefaultAsync(m => m.Id == id);
            _context.Eduction.Remove(eduction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EductionExists(int id)
        {
            return _context.Eduction.Any(e => e.Id == id);
        }
    }
}
