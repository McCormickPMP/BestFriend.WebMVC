using BestFriend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestFriend.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _dbApplication = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(_dbApplication.Products.ToList);
        }
    }
}