using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Entities;
using StudentManagment.Data;

namespace WebApplication1.Controllers
{
    public class CoachingsController : Controller
    {
        private readonly StudentManagmentDbContext _context;

        public CoachingsController(StudentManagmentDbContext context)
        {
            _context = context;
        }

        // GET: Coachings
        public async Task<IActionResult> Index()
        {
            var studentManagmentDbContext = _context.Coachings.Include(c => c.Instructor);
            return View(await studentManagmentDbContext.ToListAsync());
        }

        // GET: Coachings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coachings == null)
            {
                return NotFound();
            }

            var coaching = await _context.Coachings
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CoachingID == id);
            if (coaching == null)
            {
                return NotFound();
            }

            return View(coaching);
        }

        // GET: Coachings/Create
        public IActionResult Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "Address");
            return View();
        }

        // POST: Coachings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoachingID,InstructorID,Location,StartDate,EndDate,Topic,Feedback")] Coaching coaching)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coaching);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "Address", coaching.InstructorID);
            return View(coaching);
        }

        // GET: Coachings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Coachings == null)
            {
                return NotFound();
            }

            var coaching = await _context.Coachings.FindAsync(id);
            if (coaching == null)
            {
                return NotFound();
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "Address", coaching.InstructorID);
            return View(coaching);
        }

        // POST: Coachings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoachingID,InstructorID,Location,StartDate,EndDate,Topic,Feedback")] Coaching coaching)
        {
            if (id != coaching.CoachingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coaching);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachingExists(coaching.CoachingID))
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
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "Address", coaching.InstructorID);
            return View(coaching);
        }

        // GET: Coachings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Coachings == null)
            {
                return NotFound();
            }

            var coaching = await _context.Coachings
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CoachingID == id);
            if (coaching == null)
            {
                return NotFound();
            }

            return View(coaching);
        }

        // POST: Coachings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coachings == null)
            {
                return Problem("Entity set 'StudentManagmentDbContext.Coachings'  is null.");
            }
            var coaching = await _context.Coachings.FindAsync(id);
            if (coaching != null)
            {
                _context.Coachings.Remove(coaching);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachingExists(int id)
        {
          return (_context.Coachings?.Any(e => e.CoachingID == id)).GetValueOrDefault();
        }
    }
}
