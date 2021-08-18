using Microsoft.AspNetCore.Mvc.Rendering;
using Schedules_classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class ServiceModel
    {
        public static async Task<List<Service>> GetAllAsync()
        {
            using (var _context = new DB())
            {
                var applicationDbContext = _context.Services.Include(s => s.AspNetUser);
                return await applicationDbContext.ToListAsync();
            }
        }

        public static async Task<Service> GetServiceAsync(int? id)
        {
            using (var _context = new DB())
            {
                var service = await _context.Services
                .Include(c => c.AspNetUser)
                .FirstOrDefaultAsync(m => m.Service_id == id);
                return service;
            }
        }

        public static async Task<bool> CreateAsync(Service service)
        {
            using (var _context = new DB())
            {
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> UpdateAsync(Service service)
        {
            using (var _context = new DB())
            {
                var _service = await _context.Services.SingleOrDefaultAsync(e => e.Service_id == service.Service_id);
                if (_service == null)
                {
                    return false;
                }
                _service.Name = service.Name;
                _service.Price = service.Price;
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            using (var _context = new DB())
            {
                var service = await _context.Services.SingleOrDefaultAsync(e => e.Service_id == id);
                if (service == null)
                {
                    return false;
                }
                var order_service = await _context.Order_services.FirstOrDefaultAsync(e => e.Service_id == id);
                if (order_service != null)
                {
                    return false;
                }
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static List<SelectListItem> GetSelectList(int? selected = null)
        {
            using (var _context = new DB())
            {
                List<SelectListItem> list;
                if (selected == null)
                {
                    list = new SelectList(_context.Services, "Service_id", "Name").ToList();
                }
                else
                {
                    list = new SelectList(_context.Services, "Service_id", "Name", selected).ToList();
                }
                list.Remove(list.Find(e => e.Text == "”⁄— «·„⁄·„"));
                return list;
            }
        }

    }
}
