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
                                                   .FirstOrDefaultAsync(m => m.Client_id == id);
                return client;
            }
        }

        public static async Task<bool> CreateAsync(Client client, string channel_name)
        {
            using (var _context = new DB())
            {
                if (client.Channel_id == null)
                {
                    Channel channel = new Channel
                    {
                        Name = channel_name,
                        Added_by = client.Added_by,
                        Added_date = client.Added_date
                    };
                    channel.Clients.Add(client);
                    _context.Channels.Add(channel);
                }
                else
                {
                    _context.Clients.Add(client);
                }

                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> UpdateAsync(Client client)
        {
            using (var _context = new DB())
            {
                var _client = await _context.Clients.FirstOrDefaultAsync(e => e.Client_id == client.Client_id);
                if (_client != null)
                {
                    _client.Channel_id = client.Channel_id;
                    _client.Email = client.Email;
                    _client.Name = client.Name;
                    _client.Phone = client.Phone;
                    _client.Notes = client.Notes;
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
                var client = await _context.Clients.SingleOrDefaultAsync(e => e.Client_id == id);
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

        public static List<SelectListItem> GetSelectList(int? selected = null)
        {
            using (var _context = new DB())
            {
                List<SelectListItem> list;
                if (selected == null)
                {
                    list = new SelectList(_context.Clients, "Client_id", "Name").ToList();
                }
                else
                {
                    list = new SelectList(_context.Clients, "Client_id", "Name", selected).ToList();
                }
                return list;
            }
        }
    }
}
