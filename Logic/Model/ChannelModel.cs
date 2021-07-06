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
    public class ChannelModel
    {
        public static async Task<List<Channel>> GetAllAsync()
        {
            using (var _context = new DB())
            {
                var applicationDbContext = _context.Channels.Include(c => c.AspNetUser);
                return await applicationDbContext.ToListAsync();
            }
        }

        public static async Task<Channel> GetChannelAsync(int? id)
        {
            using (var _context = new DB())
            {
                var channel = await _context.Channels
                .Include(c => c.AspNetUser)
                .FirstOrDefaultAsync(m => m.Channel_id == id);
                return channel;
            }
        }

        public static async Task<bool> CreateAsync(Channel channel)
        {
            using (var _context = new DB())
            {
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

        public static List<SelectListItem> GetSelectList(int? selected = null)
        {
            using (var _context = new DB())
            {
                List<SelectListItem> list;
                if (selected == null)
                {
                    list = new SelectList(_context.Channels, "Channel_id", "Name").ToList();
                }
                else 
                { 
                    list = new SelectList(_context.Channels, "Channel_id", "Name", selected).ToList();
                }
                return list;
            }
        }

        public static async Task<bool> ChannelExistsAsync(Channel channel)
        {
            using (var _context = new DB())
            {
                Channel _channel = await _context.Channels.FirstOrDefaultAsync(e => e.Channel_id == channel.Channel_id);
                return _channel != null;
            }
        }
    }
}
