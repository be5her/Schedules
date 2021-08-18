using Microsoft.AspNetCore.Mvc.Rendering;
using Schedules_classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class SemesterModel
    {
        public static async Task<List<Semester>> GetAllAsync()
        {
            using (var _context = new DB())
            {
                var applicationDbContext = _context.Semesters.Include(s => s.AspNetUser);
                return await applicationDbContext.ToListAsync();
            }
        }

        public static async Task<Semester> GetSemesterAsync(int? id)
        {
            using (var _context = new DB())
            {
                var semester = await _context.Semesters
                .Include(s => s.AspNetUser)
                .FirstOrDefaultAsync(m => m.Semester_id == id);
                return semester;
            }
        }

        public static async Task<bool> CreateAsync(Semester semester)
        {
            using (var _context = new DB())
            {
                _context.Semesters.Add(semester);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> UpdateAsync(Semester semester)
        {
            using (var _context = new DB())
            {
                var _semester = await _context.Semesters.FirstOrDefaultAsync(e => e.Semester_id == semester.Semester_id);
                if (_semester != null)
                {
                    _semester.Is_active = semester.Is_active;
                    _semester.Title = semester.Title;
                    _semester.Code = semester.Code;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            using (var _context = new DB())
            {
                var semester = await _context.Semesters.SingleOrDefaultAsync(e => e.Semester_id == id);
                if (semester == null)
                {
                    return false;
                }
                var order = await _context.Orders.FirstOrDefaultAsync(e => e.Semester_id == id);
                if (order != null)
                {
                    return false;
                }
                _context.Semesters.Remove(semester);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static List<SelectListItem> GetSelectList(int? selected = null)
        {
            using (var _context = new DB())
            {
                List<SelectListItem> list;
                var sorted = _context.Semesters.ToList();
                sorted.Sort();
                if (selected == null)
                {                   
                    list = new SelectList(sorted, "Semester_id", "Code").ToList();
                }
                else
                {
                    list = new SelectList(sorted, "Semester_id", "Code", selected).ToList();
                }
                return list;
            }
        }
    }
}
