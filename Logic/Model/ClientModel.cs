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
                var clients = await _context.Clients.Include(c => c.Channel).ToListAsync();
                foreach (var client in clients)
                {
                    client.Added_by_name = client.AspNetUser.Full_name;
                }
                return clients;
            }
        }

        public static async Task<Client> GetClientAsync(int? id)
        {
            using (var _context = new DB())
            {
                var client = await _context.Clients.SingleOrDefaultAsync(m => m.Cleint_id == id);
                client.Added_by_name = client.AspNetUser.Full_name;
                return client;
            }
        }

        public static async Task<bool> CreateAsync(string name, string phone, string email, string added_by, int channel_id, string notes)
        {
            using (var _context = new DB())
            {
                var client = new Client()
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Added_by = added_by,
                    Channel_id = channel_id,
                    Added_date = DateTime.Now,
                    Notes = notes
                };
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> UpdateAsync(int id, string name, string phone, string email, int channel_id, string notes)
        {
            using (var _context = new DB())
            {
                var client = await _context.Clients.SingleOrDefaultAsync(e => e.Cleint_id == id);
                if (client == null)
                {
                    return false;
                }
                client.Name = name;
                client.Phone = phone;
                client.Email = email;
                client.Channel_id = channel_id;
                client.Notes = notes;
                await _context.SaveChangesAsync();
                return true;
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
