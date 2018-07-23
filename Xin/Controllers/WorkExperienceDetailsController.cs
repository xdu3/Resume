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
    public class WorkExperienceDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkExperienceDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkExperienceDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkExperienceDetail.Include(w => w.WorkExperience);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkExperienceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperienceDetail = await _context.WorkExperienceDetail
                .Include(w => w.WorkExperience)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (workExperienceDetail == null)
            {
                return NotFound();
            }

            return View(workExperienceDetail);
        }

        // GET: WorkExperienceDetails/Create
        public IActionResult Create()
        {
            ViewData["WorkExperienceId"] = new SelectList(_context.WorkExperience, "Id", "CompanyName");
            return View();
        }

        // POST: WorkExperienceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WEDescription,WorkExperienceId")] WorkExperienceDetail workExperienceDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workExperienceDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkExperienceId"] = new SelectList(_context.WorkExperience, "Id", "CompanyName", workExperienceDetail.WorkExperienceId);
            return View(workExperienceDetail);
        }

        // GET: WorkExperienceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperienceDetail = await _context.WorkExperienceDetail.SingleOrDefaultAsync(m => m.Id == id);
            if (workExperienceDetail == null)
            {
                return NotFound();
            }
            ViewData["WorkExperienceId"] = new SelectList(_context.WorkExperience, "Id", "CompanyName", workExperienceDetail.WorkExperienceId);
            return View(workExperienceDetail);
        }

        // POST: WorkExperienceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WEDescription,WorkExperienceId")] WorkExperienceDetail workExperienceDetail)
        {
            if (id != workExperienceDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperienceDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExperienceDetailExists(workExperienceDetail.Id))
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
            ViewData["WorkExperienceId"] = new SelectList(_context.WorkExperience, "Id", "CompanyName", workExperienceDetail.WorkExperienceId);
            return View(workExperienceDetail);
        }

        // GET: WorkExperienceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperienceDetail = await _context.WorkExperienceDetail
                .Include(w => w.WorkExperience)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (workExperienceDetail == null)
            {
                return NotFound();
            }

            return View(workExperienceDetail);
        }

        // POST: WorkExperienceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperienceDetail = await _context.WorkExperienceDetail.SingleOrDefaultAsync(m => m.Id == id);
            _context.WorkExperienceDetail.Remove(workExperienceDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExperienceDetailExists(int id)
        {
            return _context.WorkExperienceDetail.Any(e => e.Id == id);
        }
    }
}
