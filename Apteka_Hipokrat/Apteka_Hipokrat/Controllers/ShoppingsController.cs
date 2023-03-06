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
    public class ShoppingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shoppings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shoppings.Include(s => s.Medicines).Include(s => s.Users);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Shoppings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shoppings == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shoppings
                .Include(s => s.Medicines)
                .Include(s => s.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }

            return View(shopping);
        }

        // GET: Shoppings/Create
        public IActionResult Create()
        {
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Id");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Shoppings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,MedicineId,Quantity,TotalSum,RegisterON")] Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Id", shopping.MedicineId);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", shopping.UserID);
            return View(shopping);
        }

        // GET: Shoppings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shoppings == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shoppings.FindAsync(id);
            if (shopping == null)
            {
                return NotFound();
            }
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Id", shopping.MedicineId);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", shopping.UserID);
            return View(shopping);
        }

        // POST: Shoppings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,MedicineId,Quantity,TotalSum,RegisterON")] Shopping shopping)
        {
            if (id != shopping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingExists(shopping.Id))
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
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Id", shopping.MedicineId);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", shopping.UserID);
            return View(shopping);
        }

        // GET: Shoppings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shoppings == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shoppings
                .Include(s => s.Medicines)
                .Include(s => s.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopping == null)
            {
                return NotFound();
            }

            return View(shopping);
        }

        // POST: Shoppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shoppings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shoppings'  is null.");
            }
            var shopping = await _context.Shoppings.FindAsync(id);
            if (shopping != null)
            {
                _context.Shoppings.Remove(shopping);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingExists(int id)
        {
          return _context.Shoppings.Any(e => e.Id == id);
        }
    }
}
