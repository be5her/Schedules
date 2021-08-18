using Logic.Model;
using Logic.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedules_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace View.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            return await GetAllSemester(Int16.Parse((SemesterModel.GetSelectList()[0]).Value));
        }

        public async Task<IActionResult> GetAllSemester(int semester_id)
        {
            ViewData["Semester_id"] = SemesterModel.GetSelectList(semester_id);
            ViewData["Semester_title"] = (await SemesterModel.GetSemesterAsync(semester_id)).Title;
            ViewData["id"] = semester_id;
            return View("Index", await OrderModel.GetAllAsync(semester_id));
        }

        public IActionResult CreateAsync(int semester_id)
        {
            ViewData["School_id"] = SchoolModel.GetSelectList();
            ViewData["Client_id"] = ClientModel.GetSelectList();
            ViewData["Services"] = ServiceModel.GetSelectList();
            ViewData["Semester_id"] = semester_id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Semester_id,School_id,Client_id,Number_of_teachers,Services_id,Discount")] OrderView orderView)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            orderView.Added_by = userId;
            orderView.Order_date = DateTime.Now;
            await OrderModel.CreateAsync(orderView);
            return RedirectToAction("GetAllSemester", new
            {
                semester_id = orderView.Semester_id
            });
        }


        public async Task<IActionResult> Details(int id)
        {
            var order = await OrderModel.GetOrderAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }



        #region api calls
        public async Task<int?> GetClientFromSchool(int id)
        {
            return await OrderModel.GetClientFromSchool(id);
        }


        public async Task<int?> GetSchoolFromClient(int id)
        {
            return await OrderModel.GetSchoolFromClient(id);
        }


        public IActionResult AddPayment(int id)
        {
            var payment = new Payment();
            payment.Order_id = id;
            return PartialView("_AddPaymentModalPartial", payment);
        }


        [HttpPost]
        public async Task<IActionResult> AddPaymentAsync([Bind("Order_id,Payment_py,Amount,Method")] Payment payment)
        {
            payment.Payment_date = DateTime.Now;
            await OrderModel.AddPaymentAsync(payment);
            return RedirectToAction("Index");
        }

        public IActionResult NewClient()
        {
            var newClientView = new NewClientView();
            ViewData["School_id"] = SchoolModel.GetSelectList();
            ViewData["Stage_id"] = StageModal.GetSelectList();
            ViewData["Client_id"] = ClientModel.GetSelectList();
            ViewData["Channel_id"] = ChannelModel.GetSelectList();

            return PartialView("_NewClientPartial", newClientView);
        }

        [HttpPost]
        public async Task<string> NewClient([Bind("School_id,School_name,Stage_id,Client_id,Client_name,Client_phone,Channel_id")] NewClientView newClientView)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            newClientView.Added_by = userId;
            newClientView.Added_date = DateTime.Now;
            var data = await OrderModel.NewClientAsync(newClientView);
            return data;
        }
        #endregion
    }
}
