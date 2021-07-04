using Schedules_classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class ChannelModel
    {
        public static async Task<List<Channel>> GetAllAsync()
        {
            using (var _context = new DB())
            {
                var channels = await _context.Channels.ToListAsync();
                foreach (var channel in channels)
                {
                    channel.Added_by_name = channel.AspNetUser.Full_name;
                }
                return channels;
            }
        }

        public static async Task<Channel> GetChannelAsync(int? id)
        {
            using (var _context = new DB())
            {
                var channel = await _context.Channels.SingleOrDefaultAsync(m => m.Channel_id == id);
                channel.Added_by_name = channel.AspNetUser.Full_name;
                return channel;
            }
        }

        public static async Task<bool> CreateAsync(string name, string added_by)
        {
            using (var _context = new DB())
            {
                var channel = new Channel()
                {
                    Name = name,
                    Added_by = added_by,
                    Added_date = DateTime.Now
                };
                _context.Channels.Add(channel);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> UpdateAsync(int id, string name)
        {
            using (var _context = new DB())
            {
                var channel = await _context.Channels.SingleOrDefaultAsync(e => e.Channel_id == id);
                if (channel == null)
                {
                    return false;
                }
                    channel.Name = name;
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            using (var _context = new DB())
            {
                var channel = await _context.Channels.SingleOrDefaultAsync(e => e.Channel_id == id);
                if (channel == null)
                {
                    return false;
                }
                var client = await _context.Clients.FirstOrDefaultAsync(e => e.Channel_id == id);
                if (client != null)
                {
                    return false;
                }
                _context.Channels.Remove(channel);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
