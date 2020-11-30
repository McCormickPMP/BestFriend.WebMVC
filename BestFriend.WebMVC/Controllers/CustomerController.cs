using BestFriend.Data;
using BestFriend.Models.CustomerModel;
using BestFriend.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BestFriend.WebMVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Customer/Index
        
        public ActionResult Index()
        {
            CustomerService customerServices = CreateCustomerService();
            var customers = customerServices.GetCustomers();
            return View(customers);
        }
       
        public ActionResult Create()
        {
            return View();
        }

        //POST: customer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Customer could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerUpdate
                {
                    CustomerID = detail.CustomerID,
                    UserName = detail.UserName,
                    Email = detail.Email,
                    FullName = detail.FullName
                };
            return View(model);

        }
        //POST: Customer/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerID != id)
            {
                ModelState.AddModelError("", "Id Mistmatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Customer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Customer could not be updated.");
            return View(model);
        }
        // GET : Customer/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }
        //POST: Customer/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Customer was deleted.";

            return RedirectToAction("Index");
        }
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}

