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
    public class DesDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DesDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DesDetails.Include(d => d.Description);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DesDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desDetails = await _context.DesDetails
                .Include(d => d.Description)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (desDetails == null)
            {
                return NotFound();
            }

            return View(desDetails);
        }

        // GET: DesDetails/Create
        public IActionResult Create()
        {
            ViewData["DescriptionId"] = new SelectList(_context.Description, "Id", "Title");
            return View();
        }

        // POST: DesDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Detail,DescriptionId")] DesDetails desDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DescriptionId"] = new SelectList(_context.Description, "Id", "Title", desDetails.DescriptionId);
            return View(desDetails);
        }

        // GET: DesDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desDetails = await _context.DesDetails.SingleOrDefaultAsync(m => m.Id == id);
            if (desDetails == null)
            {
                return NotFound();
            }
            ViewData["DescriptionId"] = new SelectList(_context.Description, "Id", "Title", desDetails.DescriptionId);
            return View(desDetails);
        }

        // POST: DesDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Detail,DescriptionId")] DesDetails desDetails)
        {
            if (id != desDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesDetailsExists(desDetails.Id))
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
            ViewData["DescriptionId"] = new SelectList(_context.Description, "Id", "Title", desDetails.DescriptionId);
            return View(desDetails);
        }

        // GET: DesDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desDetails = await _context.DesDetails
                .Include(d => d.Description)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (desDetails == null)
            {
                return NotFound();
            }

            return View(desDetails);
        }

        // POST: DesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desDetails = await _context.DesDetails.SingleOrDefaultAsync(m => m.Id == id);
            _context.DesDetails.Remove(desDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesDetailsExists(int id)
        {
            return _context.DesDetails.Any(e => e.Id == id);
        }
    }
}
