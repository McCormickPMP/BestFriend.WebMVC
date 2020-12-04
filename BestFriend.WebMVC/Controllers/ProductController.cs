using BestFriend.Data;
using BestFriend.Models.ProductModel;
using BestFriend.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BestFriend.WebMVC.Controllers
{
    [Authorize]
    
    public class ProductController : Controller
    {
       // private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Product/Index
        public ActionResult Index()
        {
            ProductService productServices = CreateProductService();
            var products = productServices.GetProducts();
            return View(products);
        }

        //CREATE
        public ActionResult Create()
        {
            return View();
        }

        //GET Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductService();

            if (service.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your product was created.";
                 return RedirectToAction("Index");
             };

            ModelState.AddModelError("", "Product could not be created.");

            return View(model);
        }

        //GET Product/Details/{id}
        [Route("id")]
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }
        //UPDATE
        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductById(id);
            var model =
                new ProductUpdate
                {
                    Name = detail.Name,
                    Description = detail.Description,
                    Price = detail.Price,
                    InventoryCount = detail.InventoryCount,
                    ModifyProduct = detail.ModifyProduct
                };
            return View(model);

        }
        //POST: Product/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, ProductUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "ID Mistmatch");
                return View(model);
            }

            var service = CreateProductService();

            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }
        // GET : Product/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }
        //POST: Product/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your product was deleted.";

            return RedirectToAction("Index");
        }
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
    }
}