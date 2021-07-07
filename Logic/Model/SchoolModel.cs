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
    public class SchoolModel
    {
        public static async Task<List<School>> GetAllAsync()
        {
            using (var _context = new DB())
            {
                var schools = await _context.Schools.Include(s => s.AspNetUser)
                                                    .Include(s => s.Client)
                                                    .Include(s => s.Stage)
                                                    .ToListAsync();
                return schools;
            }
        }

        public static async Task<School> GetSchoolAsync(int? id)
        {
            using (var _context = new DB())
            {
                var school = await _context.Schools
                .Include(s => s.AspNetUser)
                .Include(s => s.Client)
                .Include(s => s.Stage)
                .FirstOrDefaultAsync(m => m.School_id == id);
                return school;
            }
        }

        public static async Task<bool> CreateAsync(School school, string stage_name, string client_name, int? channel_id, string channel_name)
        {
            using (var _context = new DB())
            {
                if (school.Client_id == null)
                {
                    Client client = new Client
                    {
                        Name = client_name,
                        Added_by = school.Added_by,
                        Added_date = school.Added_date,
                        Channel_id = channel_id
                    };
                    //await ClientModel.CreateAsync(client, channel_name);
                    //school.Client_id = client.Client_id;

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
                    school.Client = client;

                }
                if (school.Stage_id == null)
                {
                    Stage stage = new Stage
                    {
                        Added_by = school.Added_by,
                        Added_date = school.Added_date,
                        Name = stage_name
                    };
                    stage.Schools.Add(school);
                    _context.Stages.Add(stage);
                } else
                {
                    _context.Schools.Add(school);
                }

                await _context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<bool> UpdateAsync(School school)
        {
            using (var _context = new DB())
            {
                var _school = await _context.Schools.FirstOrDefaultAsync(e => e.School_id == school.School_id);
                if (_school != null)
                {
                    _school.Name = school.Name;
                    _school.Stage_id = school.Stage_id;
                    _school.Client_id = school.Client_id;
                    _school.Is_joined = school.Is_joined;
                    _school.Notes = school.Notes;
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
                var school = await _context.Schools.SingleOrDefaultAsync(e => e.School_id == id);
                if (school == null)
                {
                    return false;
                }
                var order = await _context.Orders.FirstOrDefaultAsync(e => e.Client_id == id);
                if (order != null)
                {
                    return false;
                }
                _context.Schools.Remove(school);
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
                    list = new SelectList(_context.Schools, "School_id", "Name").ToList();
                }
                else
                {
                    list = new SelectList(_context.Schools, "School_id", "Name", selected).ToList();
                }
                return list;
            }
        }
    }
}
