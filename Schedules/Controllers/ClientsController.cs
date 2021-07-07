using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Logic.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schedules.Data;
using Schedules_classes;

namespace View.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await ClientModel.GetAllAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = await ClientModel.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["Channel_id"] = ChannelModel.GetSelectList();
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Client_id,Name,Phone,Email,Channel_id,Notes")] Client client, string Channel_name)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            client.Added_by = userId;
            client.Added_date = DateTime.Now;
            if (ModelState.IsValid)
            {
                await ClientModel.CreateAsync(client, Channel_name);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Channel_id"] = ChannelModel.GetSelectList();
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await ClientModel.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["Channel_id"] = ChannelModel.GetSelectList(client.Channel_id);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Client_id,Name,Phone,Email,Channel_id,Notes")] Client client)
        {
            if (id != client.Client_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await ClientModel.UpdateAsync(client))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Channel_id"] = ChannelModel.GetSelectList(client.Channel_id);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await ClientModel.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await ClientModel.DeleteAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

    }
}
