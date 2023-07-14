using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Data;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Controllers
{
    public class ShopInformationController : Controller
    {
        private readonly AppDbContext _context;

        public ShopInformationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ShopInformation
        public async Task<IActionResult> Index()
        {
              return _context.ShopInformation != null ? 
                          View(await _context.ShopInformation.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.ShopInformation'  is null.");
        }

        // GET: ShopInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShopInformation == null)
            {
                return NotFound();
            }

            var shopInformation = await _context.ShopInformation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopInformation == null)
            {
                return NotFound();
            }

            return View(shopInformation);
        }

        // GET: ShopInformation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,ContactNo,PanNo")] ShopInformation shopInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopInformation);
        }

        // GET: ShopInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShopInformation == null)
            {
                return NotFound();
            }

            var shopInformation = await _context.ShopInformation.FindAsync(id);
            if (shopInformation == null)
            {
                return NotFound();
            }
            return View(shopInformation);
        }

        // POST: ShopInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,ContactNo,PanNo")] ShopInformation shopInformation)
        {
            if (id != shopInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopInformationExists(shopInformation.Id))
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
            return View(shopInformation);
        }

        // GET: ShopInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShopInformation == null)
            {
                return NotFound();
            }

            var shopInformation = await _context.ShopInformation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopInformation == null)
            {
                return NotFound();
            }

            return View(shopInformation);
        }

        // POST: ShopInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShopInformation == null)
            {
                return Problem("Entity set 'AppDbContext.ShopInformation'  is null.");
            }
            var shopInformation = await _context.ShopInformation.FindAsync(id);
            if (shopInformation != null)
            {
                _context.ShopInformation.Remove(shopInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopInformationExists(int id)
        {
          return (_context.ShopInformation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
