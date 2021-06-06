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
    public class Order_WorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Order_WorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order_Workers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order_Workers.ToListAsync());
        }

        // GET: Order_Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Workers = await _context.Order_Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_Workers == null)
            {
                return NotFound();
            }

            return View(order_Workers);
        }

        // GET: Order_Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order_Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Order_id,Service_id,Task_name,Cost")] Order_Workers order_Workers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order_Workers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order_Workers);
        }

        // GET: Order_Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Workers = await _context.Order_Workers.FindAsync(id);
            if (order_Workers == null)
            {
                return NotFound();
            }
            return View(order_Workers);
        }

        // POST: Order_Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Order_id,Service_id,Task_name,Cost")] Order_Workers order_Workers)
        {
            if (id != order_Workers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_Workers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_WorkersExists(order_Workers.Id))
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
            return View(order_Workers);
        }

        // GET: Order_Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Workers = await _context.Order_Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_Workers == null)
            {
                return NotFound();
            }

            return View(order_Workers);
        }

        // POST: Order_Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_Workers = await _context.Order_Workers.FindAsync(id);
            _context.Order_Workers.Remove(order_Workers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_WorkersExists(int id)
        {
            return _context.Order_Workers.Any(e => e.Id == id);
        }
    }
}
