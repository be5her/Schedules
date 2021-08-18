using Logic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Schedules_classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class OrderModel
    {
        public static async Task<List<OrderView>> GetAllAsync(int semester_id)
        {
            using (var _context = new DB())
            {
                var orders = await _context.Orders.Where(s => s.Semester_id == semester_id)
                                            .Include(s => s.AspNetUser)
                                            .Include(s => s.School)
                                            .Include(s => s.Client)
                                            .Include(s => s.Client.Channel)
                                            .Include(s => s.School.Stage)
                                            .Include(s => s.Payments)
                                            .Include(s => s.Order_services)
                                            .Include(s => s.Order_workers)
                                            .ToListAsync();


                

                var ordersView = new List<OrderView>(orders.Count());
                foreach (var order in orders)
                {
                    ordersView.Add(new OrderView
                    {
                        Order_id = order.Order_id,
                        School_id = order.School_id,
                        School_name = order.School.Name,
                        Stage_name = order.School.Stage.Name,
                        Is_joined = order.School.Is_joined,
                        Client_id = order.Client_id,
                        Client_name = order.Client.Name,
                        Client_phone = order.Client.Phone,
                        Semester_id = order.Semester_id,
                        Order_date = order.Order_date,
                        Number_of_teachers = order.Number_of_teachers,
                        Order_services = order.Order_services.ToList(),
                        Total_price = order.Total_price,
                        Discount = order.Discount,
                        Total_after_discount = order.Total_after_discount,
                        Haraj_percentage = order.Haraj_percentage,
                        Net_profit = order.Net_profit,
                        payments = order.Payments.ToList(),
                        Paid_amount = order.Paid_amount,
                        Remaining_amount = order.Remaining_amount,
                        Order_workers = order.Order_workers.ToList(),
                        Cost = order.Cost,
                        Added_by = order.Added_by,
                        Added_by_name = order.AspNetUser.Full_name,
                        Notes = order.Notes
                    });
                }
                return ordersView;

            }
        }

        public static async Task<OrderView> GetOrderAsync(int? id)
        {
            using (var _context = new DB())
            {
                var order = await _context.Orders.Include(s => s.AspNetUser)
                                                  .Include(s => s.School)
                                                  .Include(s => s.Client)
                                                  .Include(s => s.Client.Channel)
                                                  .Include(s => s.School.Stage)
                                                  .Include(s => s.Payments)
                                                  .Include(s => s.Order_services)
                                                  .Include(s => s.Order_workers)
                                                  .FirstOrDefaultAsync(s => s.Order_id == id);

                var orderView = new OrderView
                {
                    Order_id = order.Order_id,
                    School_id = order.School_id,
                    School_name = order.School.Name,
                    Stage_name = order.School.Stage.Name,
                    Is_joined = order.School.Is_joined,
                    Client_id = order.Client_id,
                    Client_name = order.Client.Name,
                    Client_phone = order.Client.Phone,
                    Semester_id = order.Semester_id,
                    Order_date = order.Order_date,
                    Number_of_teachers = order.Number_of_teachers,
                    Order_services = order.Order_services.ToList(),
                    Total_price = order.Total_price,
                    Discount = order.Discount,
                    Total_after_discount = order.Total_after_discount,
                    Haraj_percentage = order.Haraj_percentage,
                    Net_profit = order.Net_profit,
                    payments = order.Payments.ToList(),
                    Paid_amount = order.Paid_amount,
                    Remaining_amount = order.Remaining_amount,
                    Order_workers = order.Order_workers.ToList(),
                    Cost = order.Cost,
                    Added_by = order.Added_by,
                    Added_by_name = order.AspNetUser.Full_name,
                    Notes = order.Notes
                };

                return orderView;
            }
        }

        public static async Task<string> NewClientAsync(NewClientView newClientView)
        {
            using (var _context = new DB())
            {

                string school_name = "";
                int school_id = 0;

                string client_name = "";
                int client_id = 0;
                if (newClientView.School_id != 0 && newClientView.Client_id != 0)
                {
                    school_id = newClientView.School_id;
                    client_id = newClientView.Client_id;
                    school_name = (await _context.Schools.FirstOrDefaultAsync(e => e.School_id == school_id)).Name;
                    client_name = (await _context.Clients.FirstOrDefaultAsync(e => e.Client_id == client_id)).Name;
                } else if (newClientView.School_id != 0)
                {
                    school_id = newClientView.School_id;                  

                    var school = await _context.Schools.FirstOrDefaultAsync(e => e.School_id == school_id);

                    school_name = school.Name;
                    school_id = newClientView.School_id;
                    school_name = school.Name;

                    client_name = newClientView.Client_name;

                    var client = new Client
                    {
                        Name = newClientView.Client_name,
                        Phone = newClientView.Client_phone,
                        Channel_id = newClientView.Channel_id,
                        Added_by = newClientView.Added_by,
                        Added_date = newClientView.Added_date
                    };

                    school.Client = client;
                    await _context.SaveChangesAsync();

                    client_id = school.Client_id ?? 0;

                } else if (newClientView.Client_id != 0)
                {
                    client_id = newClientView.Client_id;

                    var client = await _context.Clients.FirstOrDefaultAsync(e => e.Client_id == client_id);

                    client_name = client.Name;

                    var school = new School
                    {
                        Name = newClientView.School_name,
                        Stage_id = newClientView.Stage_id,
                        Client_id = client_id,
                        Added_by = newClientView.Added_by,
                        Added_date = newClientView.Added_date,
                        Client = client
                    };

                    _context.Schools.Add(school);
                    await _context.SaveChangesAsync();

                    school_name = school.Name;
                    school_id = school.School_id;

                } else
                {
                    school_name = newClientView.School_name;
                    client_name = newClientView.Client_name;

                    var client = new Client
                    {
                        Name = newClientView.Client_name,
                        Phone = newClientView.Client_phone,
                        Channel_id = newClientView.Channel_id,
                        Added_by = newClientView.Added_by,
                        Added_date = newClientView.Added_date
                    };

                    var school = new School
                    {
                        Name = newClientView.School_name,
                        Stage_id = newClientView.Stage_id,
                        Added_by = newClientView.Added_by,
                        Added_date = newClientView.Added_date,
                        Client = client
                    };

                    _context.Schools.Add(school);
                    await _context.SaveChangesAsync();

                    school_id = school.School_id;
                    client_id = school.Client_id ?? 0;
                }

                return $"{{\"school\": {{\"text\": \"{school_name}\", \"value\": {school_id} }}, \"client\" : {{\"text\": \"{client_name}\", \"value\": {client_id} }} }}";
            }
        }

        public static async Task<bool> CreateAsync(OrderView orderView)
        {

            using (var _context = new DB())
            {
                orderView.Order_services = new List<Order_services>(orderView.Services_id.Count);
                foreach (var id in orderView.Services_id)
                {
                    orderView.Order_services.Add(new Order_services { Service_id = id});
                }
                var totalPrice = await getTotalPriceAsync(orderView.Number_of_teachers, orderView.School_id, orderView.Order_services);
                var totalAfterDiscount = orderView.Discount > 0 ? totalPrice - orderView.Discount : totalPrice;
                orderView.Channel_name = (await _context.Clients.Include(e => e.Channel).FirstOrDefaultAsync(e => e.Client_id == orderView.Client_id)).Channel.Name;
                var harajPercentage = getHarajPercentage(orderView.Channel_name, totalAfterDiscount);
                var order = new Order
                {
                    School_id = orderView.School_id,
                    Client_id = orderView.Client_id,
                    Semester_id = orderView.Semester_id,
                    Order_date = orderView.Order_date,
                    Number_of_teachers = orderView.Number_of_teachers,
                    Total_price = totalPrice,
                    Discount = orderView.Discount,
                    Total_after_discount = totalAfterDiscount,
                    Haraj_percentage = harajPercentage,
                    Net_profit = harajPercentage > 0 ? totalAfterDiscount - harajPercentage : totalAfterDiscount,
                    Paid_amount = orderView.Paid_amount ?? 0,
                    Remaining_amount = totalAfterDiscount,
                    Added_by = orderView.Added_by,
                    Order_services = orderView.Order_services,
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        private static decimal getHarajPercentage(string channel_name, decimal totalAfterDiscount)
        {
            if (channel_name.Trim() == "حراج")
            {
                return totalAfterDiscount * 0.01m;
            }
            return 0;
        }

        private static async Task<decimal> getTotalPriceAsync(int? numberOfTeachers, int? schoolId, List<Order_services> services)
        {
            using (var _context = new DB())
            {
                var isJoined = (await _context.Schools.FirstOrDefaultAsync(e => e.School_id == schoolId)).Is_joined;
                var _services = await _context.Services.ToListAsync();
                var Base_service = await _context.Services.FirstOrDefaultAsync(e => e.Name == "إنشاء جدول");
                decimal total = 0.0m;
             //(await _context.Services.FirstOrDefaultAsync(e => e.Name == "إنشاء جدول")).Price +
             //
                //total += Convert.ToInt32(isJoined) * (await _context.Services.FirstOrDefaultAsync(e => e.Name == "مدرسة مشتركة")).Price ?? 0;

                foreach (var service in services)
                {
                    if (service.Service_id == Base_service.Service_id)
                    {
                        var temp = ((await _context.Services.FirstOrDefaultAsync(e => e.Name == "سعر المعلم")).Price * numberOfTeachers) + Base_service.Price ?? 0;
                        total += temp;
                        service.Current_Price = temp;
                    } else
                    {
                        var temp = (await _context.Services.FirstOrDefaultAsync(e => e.Service_id == service.Service_id)).Price;
                        total += temp ?? 0;
                        service.Current_Price = temp;
                    }
                }
                return total;
            }
        }

        public static async Task<bool> AddPaymentAsync(Payment payment)
        {
            using (var _context = new DB())
            {
                var order = await _context.Orders.FirstOrDefaultAsync(e => e.Order_id == payment.Order_id);
                if (order == null)
                {
                    return false;
                }
                order.Paid_amount += payment.Amount;
                order.Remaining_amount -= payment.Amount;
                _context.Payments.Add(payment);
                _context.SaveChanges();
                return true;
            }
        }


        public static async Task<int?> GetClientFromSchool(int id)
        {
            using (var _context = new DB())
            {
               return (await _context.Schools.FirstOrDefaultAsync(e => e.School_id == id)).Client_id;
            }
        }

        public static async Task<int?> GetSchoolFromClient(int id)
        {
            using (var _context = new DB())
            {
                return (await _context.Schools.FirstOrDefaultAsync(e => e.Client_id == id)).School_id;
            }
        }
    }
}
