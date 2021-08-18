using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Logic.Model;
using Logic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schedules.Data;
using Schedules_classes;

namespace View.Controllers
{
    public class SchoolsController : Controller
    {

        // GET: Schools
        public async Task<IActionResult> Index()
        {
            return View(await SchoolModel.GetAllAsync());
        }

        // GET: Schools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await SchoolModel.GetSchoolAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: Schools/Create
        public IActionResult Create()
        {
            ViewData["Client_id"] = ClientModel.GetSelectList();
            ViewData["Stage_id"] = StageModal.GetSelectList();
            ViewData["Channel_id"] = ChannelModel.GetSelectList();
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("School_name,Stage_id,Stage_name,Client_id,Client_name,Is_joined,Channel_id,Channel_name,Notes")] SchoolView SchoolView)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SchoolView.Added_by = userId;
            SchoolView.Added_date = DateTime.Now;
            

            if (ModelState.IsValid)
            {
                await SchoolModel.CreateAsync(SchoolView);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Client_id"] = ClientModel.GetSelectList(SchoolView.Client_id);
            ViewData["Stage_id"] = StageModal.GetSelectList(SchoolView.Stage_id);
            ViewData["Channel_id"] = ChannelModel.GetSelectList(SchoolView.Stage_id);
            return View(SchoolView);
        }

        // GET: Schools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await SchoolModel.GetSchoolAsync(id);
            if (school == null)
            {
                return NotFound();
            }
            ViewData["Client_id"] = ClientModel.GetSelectList(school.Client_id);
            ViewData["Stage_id"] = StageModal.GetSelectList(school.Stage_id);
            return View(school);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("School_id,School_name,Stage_id,Stage_name,Client_id,Client_name,Is_joined,Channel_id,Channel_name,Notes")] SchoolView SchoolView)
        {
            if (id != SchoolView.School_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await SchoolModel.UpdateAsync(SchoolView))
                {
                    return RedirectToAction(nameof(Index));
                } else
                {
                    return NotFound();
                }
            }
            ViewData["Client_id"] = ClientModel.GetSelectList(SchoolView.Client_id);
            ViewData["Stage_id"] = StageModal.GetSelectList(SchoolView.Stage_id);
            return View(SchoolView);
        }

        // GET: Schools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await SchoolModel.GetSchoolAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await SchoolModel.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
