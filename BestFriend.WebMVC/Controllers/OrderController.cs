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
        //private ApplicationDbContext _db = new ApplicationDbContext();
       
        // GET: Order/Index
        public ActionResult Index()
        {
            //var orderGuid = Guid.Parse(User.Identity.GetUserId());
            //var service = new OrderService(orderGuid);
            //var model = service.GetOrders();
            //return View(model);
           OrderService orderServices = CreateOrderService();
            var orders = orderServices.GetOrders();
            return View(orders);
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
        public ActionResult Details(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateOrderService();
            var detail = service.GetOrderById(id);
            var model =
                new OrderUpdate
                {
                     OrderId = detail.OrderId,
                     CustomerId = detail.CustomerId,
                     Email = detail.Email,
                     Category = detail.Category,

                     Quantity = detail.Quantity,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrderId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateOrderService();

            if (service.UpdateOrder(model))
            {
                TempData["SaveResult"] = "Your order was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your order could not be updated.");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOrderService();

            service.DeleteOrder(id);

            TempData["SaveResult"] = "Your order was deleted";

            return RedirectToAction("Index");
        }

        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(userId);
            return service;
        }
    }
}