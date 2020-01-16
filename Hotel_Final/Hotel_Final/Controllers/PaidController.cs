using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Final.Models;
using Microsoft.AspNet.Identity;

namespace Hotel_Final.Controllers
{
    public class PaidController : BaseController
    {
        // GET: Paid
        public ActionResult Index()
        {
            var model = new vwProdCat()
            {
                Categories = db.Categories.OrderBy(cat=>cat.Name).ToList(),
                Products = db.Products.OrderBy(prod=>prod.OrderBy).ToList()
            };
            return View(model);
        }
        public JsonResult Products(int? id)
        {
            if (id == null)
            {
                return Json( db.Products.Select(prod=> new { prod.Name, prod.OrderBy, prod.Price, prod.Id }).ToList(), JsonRequestBehavior.AllowGet);
            }
            var product = db.Products.Where(prod => prod.CategoryId == id).OrderBy(o => o.OrderBy).ToList();
            if (product.Count==0)
            {

                return Json(new
                {
                    status = 405,
                    message = "Bu product siyahida yoxdur"
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(
                product.Select(prod => new 
            { prod.Name, prod.OrderBy, prod.Price, prod.Id }),
                JsonRequestBehavior.AllowGet);

        }

        public JsonResult AddOrder(int id, int count)
        {
            if (id==null)
            {
                return Json(new { status = 407, message = "id bosdur" }, JsonRequestBehavior.AllowGet);
            };
            var order = new OrderHistory();
            order.ProductId = id;
            order.OrderCount = count;
            order.ApplicationUserId = User.Identity.GetUserId();
            if (User.Identity.GetUserId() == null)
            {
                return Json(new { status = 432 }, JsonRequestBehavior.AllowGet);
            }
            order.CreatedDate.ToString("ddMMyyyy");
            db.OrderHistories.Add(order);
            db.SaveChanges();
            return Json(new { status=200,message="yaxsi"},JsonRequestBehavior.AllowGet);
        }
    }
}