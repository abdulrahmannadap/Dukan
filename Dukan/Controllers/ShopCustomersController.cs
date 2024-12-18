using Dukan.Data;
using Dukan.Models.Master;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dukan.Controllers
{
    public class ShopCustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopCustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShopCustomers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopCustomers.ToListAsync());
        }

        // GET: ShopCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCustomer = await _context.ShopCustomers
                .FirstOrDefaultAsync(m => m.SCusId == id);
            if (shopCustomer == null)
            {
                return NotFound();
            }

            return View(shopCustomer);
        }

        // GET: ShopCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SCusId,ScusName,ScusAdd,ScusShopName,JoindDate,ScusMobileNo,ScusAddharNo,ScusGSTNo")] ShopCustomer shopCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopCustomer);
        }

        // GET: ShopCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCustomer = await _context.ShopCustomers.FindAsync(id);
            if (shopCustomer == null)
            {
                return NotFound();
            }
            return View(shopCustomer);
        }

        // POST: ShopCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SCusId,ScusName,ScusAdd,ScusShopName,JoindDate,ScusMobileNo,ScusAddharNo,ScusGSTNo")] ShopCustomer shopCustomer)
        {
            if (id != shopCustomer.SCusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopCustomerExists(shopCustomer.SCusId))
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
            return View(shopCustomer);
        }

        // GET: ShopCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopCustomer = await _context.ShopCustomers
                .FirstOrDefaultAsync(m => m.SCusId == id);
            if (shopCustomer == null)
            {
                return NotFound();
            }

            return View(shopCustomer);
        }

        // POST: ShopCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopCustomer = await _context.ShopCustomers.FindAsync(id);
            if (shopCustomer != null)
            {
                _context.ShopCustomers.Remove(shopCustomer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopCustomerExists(int id)
        {
            return _context.ShopCustomers.Any(e => e.SCusId == id);
        }
    }
}
