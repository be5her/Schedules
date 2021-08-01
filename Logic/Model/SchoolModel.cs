using Logic.ViewModel;
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
        public static async Task<List<SchoolView>> GetAllAsync()
        {
            using (var _context = new DB())
            {
                var schools = await _context.Schools.Include(s => s.AspNetUser)
                                                    .Include(s => s.Client)
                                                    .Include(s => s.Client.Channel)
                                                    .Include(s => s.Stage)
                                                    .ToListAsync();
                var schoolsView = new List<SchoolView>(schools.Count);
                foreach (var school in schools)
                {
                    schoolsView.Add(new SchoolView
                    {
                        School_id = school.School_id,
                        School_name = school.Name,
                        Stage_id = school.Stage_id,
                        Stage_name = school.Stage.Name,
                        Client_id = school.Client_id,
                        Client_name = school.Client.Name,
                        Client_phone = school.Client.Phone,
                        Client_email = school.Client.Email,
                        Is_joined = school.Is_joined,
                        Channel_id = school.Client.Channel_id,
                        Channel_name = school.Client.Channel.Name,
                        Added_by = school.Added_by,
                        Added_by_name = school.AspNetUser.Full_name,
                        Added_date = school.Added_date,
                        Notes = school.Notes
                    });
                }

                return schoolsView;
            }
        }

        public static async Task<SchoolView> GetSchoolAsync(int? id)
        {
            using (var _context = new DB())
            {
                var school = await _context.Schools
                .Include(s => s.AspNetUser)
                .Include(s => s.Client)
                .Include(s => s.Stage)
                .FirstOrDefaultAsync(m => m.School_id == id);
                var schoolView = new SchoolView
                {
                    School_id = school.School_id,
                    School_name = school.Name,
                    Stage_id = school.Stage_id,
                    Stage_name = school.Stage.Name,
                    Client_id = school.Client_id,
                    Client_name = school.Client.Name,
                    Client_phone = school.Client.Phone,
                    Client_email = school.Client.Email,
                    Is_joined = school.Is_joined,
                    Channel_id = school.Client.Channel_id,
                    Channel_name = school.Client.Channel.Name,
                    Added_by = school.Added_by,
                    Added_by_name = school.AspNetUser.Full_name,
                    Added_date = school.Added_date,
                    Notes = school.Notes
                };
                return schoolView;
            }
        }

        public static async Task<bool> CreateAsync(SchoolView SchoolView)
        {
            var school = new School
            {
                Name = SchoolView.School_name,
                Stage_id = SchoolView.Stage_id,
                Client_id = SchoolView.Client_id,
                Is_joined = SchoolView.Is_joined,
                Added_by = SchoolView.Added_by,
                Added_date = SchoolView.Added_date,
                Notes = SchoolView.Notes

            };
            using (var _context = new DB())
            {
                if (SchoolView.Client_id == null)
                {
                    Client client = new Client
                    {
                        Name = SchoolView.Client_name,
                        Added_by = SchoolView.Added_by,
                        Added_date = SchoolView.Added_date,
                        Channel_id = SchoolView.Channel_id
                    };

                    if (client.Channel_id == null)
                    {
                        Channel channel = new Channel
                        {
                            Name = SchoolView.Channel_name,
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
                if (SchoolView.Stage_id == null)
                {
                    Stage stage = new Stage
                    {
                        Added_by = SchoolView.Added_by,
                        Added_date = SchoolView.Added_date,
                        Name = SchoolView.Stage_name
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

        public static async Task<bool> UpdateAsync(SchoolView SchoolView)
        {
            using (var _context = new DB())
            {
                var _school = await _context.Schools.FirstOrDefaultAsync(e => e.School_id == SchoolView.School_id);
                if (_school != null)
                {
                    _school.Name = SchoolView.School_name;
                    _school.Stage_id = SchoolView.Stage_id;
                    _school.Client_id = SchoolView.Client_id;
                    _school.Is_joined = SchoolView.Is_joined;
                    _school.Notes = SchoolView.Notes;
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
