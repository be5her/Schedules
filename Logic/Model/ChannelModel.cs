using Schedules_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class ChannelModel
    {
        
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

        public static List<Channel> GetAll()
        {
            using (var _context = new DB())
            {
                var channels = _context.Channels.ToList();
                foreach(var channel in channels)
                {
                    var user = _context.AspNetUsers.Find(channel.Added_by);
                    channel.Added_by_name = (user.First_name + " " + user.Last_name);
                }
                return channels;
            }
        }
    }
}
