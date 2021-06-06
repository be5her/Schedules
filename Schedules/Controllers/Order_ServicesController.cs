using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schedules.Data;
using Schedules_classes;

namespace Schedules.Controllers
{
    public class Order_ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Order_ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order_Services
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order_Services.ToListAsync());
        }

        // GET: Order_Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Services = await _context.Order_Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_Services == null)
            {
                return NotFound();
            }

            return View(order_Services);
        }

        // GET: Order_Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order_Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Order_id,Service_id,Current_price")] Order_Services order_Services)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order_Services);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order_Services);
        }

        // GET: Order_Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Services = await _context.Order_Services.FindAsync(id);
            if (order_Services == null)
            {
                return NotFound();
            }
            return View(order_Services);
        }

        // POST: Order_Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Order_id,Service_id,Current_price")] Order_Services order_Services)
        {
            if (id != order_Services.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_Services);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_ServicesExists(order_Services.Id))
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
            return View(order_Services);
        }

        // GET: Order_Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Services = await _context.Order_Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_Services == null)
            {
                return NotFound();
            }

            return View(order_Services);
        }

        // POST: Order_Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_Services = await _context.Order_Services.FindAsync(id);
            _context.Order_Services.Remove(order_Services);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_ServicesExists(int id)
        {
            return _context.Order_Services.Any(e => e.Id == id);
        }
    }
}
