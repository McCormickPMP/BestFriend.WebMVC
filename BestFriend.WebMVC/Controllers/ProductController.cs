using BestFriend.Models;
using BestFriend.Models.ProductModel;
using BestFriend.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestFriend.WebMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
          
            return View();
        }
        //GET: CREATE
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);

            service.CreateProduct(model);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}