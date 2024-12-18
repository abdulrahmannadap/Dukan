using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dukan.Data;
using Dukan.Models.Bill;

namespace Dukan.Controllers
{
    public class ShopCusBillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopCusBillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShopCusBills
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ShopCusBills.Include(s => s.Products).Include(s => s.ShopCustomers).Include(s => s.ShopDetails);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ShopCusBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCusBill = await _context.ShopCusBills
                .Include(s => s.Products)
                .Include(s => s.ShopCustomers)
                .Include(s => s.ShopDetails)
                .FirstOrDefaultAsync(m => m.SopCusBId == id);
            if (shopCusBill == null)
            {
                return NotFound();
            }

            return View(shopCusBill);
        }

        // GET: ShopCusBills/Create
        public IActionResult Create()
        {
            ViewData["ProId"] = new SelectList(_context.Products, "ProId",        "ProName"        );
            ViewData["SCusId"] = new SelectList(_context.ShopCustomers, "SCusId", "ScusShopName"  );
            ViewData["SpDetId"] = new SelectList(_context.ShopDetails, "SpDetId", "ShopName"      );
            return View();
        }

        // POST: ShopCusBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SopCusBId,SpDetId,SCusId,ProId,Quantity,Amount,Percentage")] ShopCusBill shopCusBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopCusBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProId"] = new SelectList(_context.Products, "ProId",        "ProName"              , shopCusBill.ProId);
            ViewData["SCusId"] = new SelectList(_context.ShopCustomers, "SCusId", "ScusShopName"   , shopCusBill.SCusId);
            ViewData["SpDetId"] = new SelectList(_context.ShopDetails, "SpDetId", "ShopName"       , shopCusBill.SpDetId);
            return View(shopCusBill);
        }

        // GET: ShopCusBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCusBill = await _context.ShopCusBills.FindAsync(id);
            if (shopCusBill == null)
            {
                return NotFound();
            }
            ViewData["ProId"] = new SelectList(_context.Products, "ProId", "ProName", shopCusBill.ProId);
            ViewData["SCusId"] = new SelectList(_context.ShopCustomers, "SCusId", "ScusShopName", shopCusBill.SCusId);
            ViewData["SpDetId"] = new SelectList(_context.ShopDetails, "SpDetId", "ShopName", shopCusBill.SpDetId);
            return View(shopCusBill);
        }

        // POST: ShopCusBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SopCusBId,SpDetId,SCusId,ProId,Quantity,Amount,Percentage")] ShopCusBill shopCusBill)
        {
            if (id != shopCusBill.SopCusBId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopCusBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopCusBillExists(shopCusBill.SopCusBId))
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
            ViewData["ProId"] = new SelectList(_context.Products, "ProId", "ProName", shopCusBill.ProId);
            ViewData["SCusId"] = new SelectList(_context.ShopCustomers, "SCusId", "ScusShopName", shopCusBill.SCusId);
            ViewData["SpDetId"] = new SelectList(_context.ShopDetails, "SpDetId", "ShopName", shopCusBill.SpDetId);
            return View(shopCusBill);
        }

        // GET: ShopCusBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCusBill = await _context.ShopCusBills
                .Include(s => s.Products)
                .Include(s => s.ShopCustomers)
                .Include(s => s.ShopDetails)
                .FirstOrDefaultAsync(m => m.SopCusBId == id);
            if (shopCusBill == null)
            {
                return NotFound();
            }

            return View(shopCusBill);
        }

        // POST: ShopCusBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopCusBill = await _context.ShopCusBills.FindAsync(id);
            if (shopCusBill != null)
            {
                _context.ShopCusBills.Remove(shopCusBill);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopCusBillExists(int id)
        {
            return _context.ShopCusBills.Any(e => e.SopCusBId == id);
        }
    }
}
