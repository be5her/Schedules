using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schedules.Data;
using Schedules_classes;
using Logic.Model;
using Microsoft.AspNetCore.Identity;
using Schedules.Models;
using System.Security.Claims;

namespace View.Controllers
{
    public class ChannelsController : Controller
    {

        // GET: Channels
        public async Task<IActionResult> Index()
        {
            return View(await ChannelModel.GetAllAsync());
        }

        // GET: Channels/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
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
        public async Task<IActionResult> Create(string Name)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (await ChannelModel.CreateAsync(Name, userId))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(Name);
        }

        // GET: Channels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var channel = await ChannelModel.GetChannelAsync(id);
            if (channel == null)
            {
                return NotFound();
            }
            return View(channel);
        }

        // POST: Channels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Channel_id, string Name)
        {
            if (await ChannelModel.UpdateAsync(Channel_id, Name))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
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
            if (await ChannelModel.DeleteAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        //private bool ChannelExists(int id)
        //{
        //    return _context.Channel.Any(e => e.Channel_id == id);
        //}
    }
}
