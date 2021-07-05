using Schedules_classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class ClientModel
    {
        public static async Task<List<Client>> GetAllAsync()
        {
            using (var _context = new DB())
            {
                var clients = await _context.Clients.Include(c => c.AspNetUser)
                                                    .Include(c => c.Channel)
                                                    .ToListAsync();
                return clients;
            }
        }

        public static async Task<Client> GetClientAsync(int? id)
        {
            using (var _context = new DB())
            {
                var client = await _context.Clients.Include(c => c.AspNetUser)
                                                   .Include(c => c.Channel)
                                                   .FirstOrDefaultAsync(m => m.Cleint_id == id);
                return client;
            }
        }

        public static async Task<bool> CreateAsync(Client client)
        {
            using (var _context = new DB())
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> UpdateAsync(Client client)
        {
            using (var _context = new DB())
            {
                if (await _context.Clients.FirstOrDefaultAsync(e => e.Cleint_id == client.Cleint_id) != null)
                {
                    _context.Entry(client).State = EntityState.Modified;
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
                var client = await _context.Clients.SingleOrDefaultAsync(e => e.Cleint_id == id);
                if (client == null)
                {
                    return false;
                }
                var school = await _context.Schools.FirstOrDefaultAsync(e => e.Client_id == id);
                if (school != null)
                {
                    return false;
                }
                var order = await _context.Orders.FirstOrDefaultAsync(e => e.Client_id == id);
                if (order != null)
                {
                    return false;
                }
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
