using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Logic.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schedules.Data;
using Schedules_classes;

namespace View.Controllers
{
    [Authorize]
    public class ChannelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChannelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Channels
        public async Task<IActionResult> Index()
        {
            return View(await ChannelModel.GetAllAsync());
        }

        // GET: Channels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await ChannelModel.GetChannelAsync(id);
            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }

        // GET: Channels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Channels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Channel_id,Name")] Channel channel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            channel.Added_by = userId;
            channel.Added_date = DateTime.Now;
            if (ModelState.IsValid)
            {
                await ChannelModel.CreateAsync(channel);
                return RedirectToAction(nameof(Index));
            }
            return View(channel);
        }

        // GET: Channels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await ChannelModel.GetChannelAsync(id);
            if (channel == null)
            {
                return NotFound();
            }
            //ViewData["Added_by"] = new SelectList(_context.Set<AspNetUser>(), "Id", "Id", channel.Added_by);
            return View(channel);
        }

        // POST: Channels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Channel_id,Name")] Channel channel)
        {
            if (id != channel.Channel_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await ChannelModel.UpdateAsync(id, channel.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(channel);
        }

        // GET: Channels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await ChannelModel.GetChannelAsync(id);
            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }

        // POST: Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ChannelModel.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
