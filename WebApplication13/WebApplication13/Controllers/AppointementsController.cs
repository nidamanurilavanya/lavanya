using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class AppointementsController : Controller
    {
        private readonly HosptialContext _context;

        public AppointementsController(HosptialContext context)
        {
            _context = context;
        }

        // GET: Appointements
        public async Task<IActionResult> Index()
        {
            var hosptialContext = _context.appointements.Include(a => a.doc).Include(a => a.pt);
            return View(await hosptialContext.ToListAsync());
        }

        // GET: Appointements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.appointements == null)
            {
                return NotFound();
            }

            var appointement = await _context.appointements
                .Include(a => a.doc)
                .Include(a => a.pt)
                .FirstOrDefaultAsync(m => m.id == id);
            if (appointement == null)
            {
                return NotFound();
            }

            return View(appointement);
        }


        public JsonResult Speciality(int id)
        {
            string speciality = "";
            switch (id)
            {
                case 1:
                    speciality = "Cardiology";
                    break;
                case 2:
                    speciality = "Gynecology";
                    break;
                case 3:
                    speciality = "Orthopedics";
                    break;
            }
            var doc = _context.Doctors.Where(e => e.speciality == speciality).Select(e => new
            {
                Id = e.id,
                text = e.name
            });
            return Json(doc);
        }

        // GET: Appointements/Create
        public IActionResult Create()
        {
            ViewData["docid"] = new SelectList(_context.Doctors, "id", "id");
            ViewData["ptid"] = new SelectList(_context.patients, "id", "id");
            return View();
        }

        // POST: Appointements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ptid,docid,AppointDate")] Appointement appointement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["docid"] = new SelectList(_context.Doctors, "id", "id", appointement.docid);
            ViewData["ptid"] = new SelectList(_context.patients, "id", "id", appointement.ptid);
            return View(appointement);
        }

        // GET: Appointements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.appointements == null)
            {
                return NotFound();
            }

            var appointement = await _context.appointements.FindAsync(id);
            if (appointement == null)
            {
                return NotFound();
            }
            ViewData["docid"] = new SelectList(_context.Doctors, "id", "id", appointement.docid);
            ViewData["ptid"] = new SelectList(_context.patients, "id", "id", appointement.ptid);
            return View(appointement);
        }

        // POST: Appointements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ptid,docid,AppointDate")] Appointement appointement)
        {
            if (id != appointement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointementExists(appointement.id))
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
            ViewData["docid"] = new SelectList(_context.Doctors, "id", "id", appointement.docid);
            ViewData["ptid"] = new SelectList(_context.patients, "id", "id", appointement.ptid);
            return View(appointement);
        }

        // GET: Appointements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.appointements == null)
            {
                return NotFound();
            }

            var appointement = await _context.appointements
                .Include(a => a.doc)
                .Include(a => a.pt)
                .FirstOrDefaultAsync(m => m.id == id);
            if (appointement == null)
            {
                return NotFound();
            }

            return View(appointement);
        }

        // POST: Appointements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.appointements == null)
            {
                return Problem("Entity set 'HosptialContext.appointements'  is null.");
            }
            var appointement = await _context.appointements.FindAsync(id);
            if (appointement != null)
            {
                _context.appointements.Remove(appointement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointementExists(int id)
        {
          return (_context.appointements?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
