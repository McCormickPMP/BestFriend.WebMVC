using BestFriend.Data;
using BestFriend.Models.OrderModel;
using BestFriend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BestFriend.WebMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
       
        // GET: Order/Index
        public ActionResult Index()
        {
            var orderGuid = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(orderGuid);
            var model = service.GetOrders();
            return View(model);
           // OrderService orderServices = CreateOrderService();
            //var orders = orderServices.GetOrders();
            //return View(orders);
            //var model = new OrderListItem[0];
            //return View(model);
        }
        //GET Create Order
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateOrderService();

            if (service.CreateOrder(model))
            {
                TempData["SaveResult"] = "Your order was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Order could not be created.");
            return View(model);
        }

        private OrderService CreateOrderService()
        {
            var orderGuid = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(orderGuid);
            return service;
        }
    }
}