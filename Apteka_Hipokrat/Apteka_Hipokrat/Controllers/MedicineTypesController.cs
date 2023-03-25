using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apteka_Hipokrat.Data;
using Apteka_Hipokrat.Models;

namespace Apteka_Hipokrat.Controllers
{
    public class MedicineTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicineTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicineTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.MedicineTypes.ToListAsync());
        }

        // GET: MedicineTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicineTypes == null)
            {
                return NotFound();
            }

            var medicineType = await _context.MedicineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        // GET: MedicineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicineTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MedicineType medicineType)
        {
            if (ModelState.IsValid)
            {
                medicineType.RegisterON = DateTime.Now;
                _context.Add(medicineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicineType);
        }

        // GET: MedicineTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicineTypes == null)
            {
                return NotFound();
            }

            var medicineType = await _context.MedicineTypes.FindAsync(id);
            if (medicineType == null)
            {
                return NotFound();
            }
            return View(medicineType);
        }

        // POST: MedicineTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RegisterON")] MedicineType medicineType)
        {
            if (id != medicineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineTypeExists(medicineType.Id))
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
            return View(medicineType);
        }

        // GET: MedicineTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicineTypes == null)
            {
                return NotFound();
            }

            var medicineType = await _context.MedicineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        } 

        // POST: MedicineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicineTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicineTypes'  is null.");
            }
            var medicineType = await _context.MedicineTypes.FindAsync(id);
            if (medicineType != null)
            {
                _context.MedicineTypes.Remove(medicineType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 

        private bool MedicineTypeExists(int id)
        {
          return _context.MedicineTypes.Any(e => e.Id == id);
        }
    }
}
