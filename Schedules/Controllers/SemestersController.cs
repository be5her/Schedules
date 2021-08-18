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
    public class SemestersController : Controller
    {

        // GET: Semesters
        public async Task<IActionResult> Index()
        {
            return View(await SemesterModel.GetAllAsync());
        }

        // GET: Semesters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await SemesterModel.GetSemesterAsync(id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        // GET: Semesters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Semesters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Semester_id,Code,Title,Is_active")] Semester semester)
        {
            semester.Added_by = User.FindFirstValue(ClaimTypes.NameIdentifier);
            semester.Added_date = DateTime.Now;
            if (ModelState.IsValid)
            {
                await SemesterModel.CreateAsync(semester);
                return RedirectToAction(nameof(Index));
            }
            return View(semester);
        }

        // GET: Semesters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await SemesterModel.GetSemesterAsync(id);
            if (semester == null)
            {
                return NotFound();
            }
            return View(semester);
        }

        // POST: Semesters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Semester_id,Code,Title,Is_active")] Semester semester)
        {
            if (id != semester.Semester_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await SemesterModel.UpdateAsync(semester))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(semester);
        }

        // GET: Semesters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await SemesterModel.GetSemesterAsync(id);
            if (semester == null)
            {
                return NotFound();
            }

            return View(semester);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await SemesterModel.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
