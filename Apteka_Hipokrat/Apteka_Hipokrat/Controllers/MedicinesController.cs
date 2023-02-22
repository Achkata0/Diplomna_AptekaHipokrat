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
    public class MedicinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medicines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Medicines.Include(m => m.MedicineTypes).Include(m => m.Producers).Include(m => m.SideEffects);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines
                .Include(m => m.MedicineTypes)
                .Include(m => m.Producers)
                .Include(m => m.SideEffects)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            ViewData["MedicineTypeId"] = new SelectList(_context.MedicineTypes, "Id", "Name");
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Name");
            ViewData["SideEffectId"] = new SelectList(_context.SideEffects, "Id", "Description");
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CatalogNumber,Composition,Apply,SideEffectId,Price,MedicineTypeId,RegisterON,ProducerId,Description")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineTypeId"] = new SelectList(_context.MedicineTypes, "Id", "Id", medicine.MedicineTypeId);
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", medicine.ProducerId);
            ViewData["SideEffectId"] = new SelectList(_context.SideEffects, "Id", "Id", medicine.SideEffectId);
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            ViewData["MedicineTypeId"] = new SelectList(_context.MedicineTypes, "Id", "Id", medicine.MedicineTypeId);
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", medicine.ProducerId);
            ViewData["SideEffectId"] = new SelectList(_context.SideEffects, "Id", "Id", medicine.SideEffectId);
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CatalogNumber,Composition,Apply,SideEffectId,Price,MedicineTypeId,RegisterON,ProducerId,Description")] Medicine medicine)
        {
            if (id != medicine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.Id))
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
            ViewData["MedicineTypeId"] = new SelectList(_context.MedicineTypes, "Id", "Id", medicine.MedicineTypeId);
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", medicine.ProducerId);
            ViewData["SideEffectId"] = new SelectList(_context.SideEffects, "Id", "Id", medicine.SideEffectId);
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines
                .Include(m => m.MedicineTypes)
                .Include(m => m.Producers)
                .Include(m => m.SideEffects)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Medicines'  is null.");
            }
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(int id)
        {
          return _context.Medicines.Any(e => e.Id == id);
        }
    }
}
