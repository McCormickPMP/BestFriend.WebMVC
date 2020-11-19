using BestFriend.Models;
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
            var model = new ProductListItem[0];
            return View();
        }
        //GET: CREATE
        public ActionResult Create()
        {
            return View();
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