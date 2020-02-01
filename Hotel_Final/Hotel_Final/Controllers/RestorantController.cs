using Hotel_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Final.Controllers
{
    public class RestorantController : BaseController
    {
        // GET: Restorant
        public ActionResult Restoran()
        {

            var model = new vwProdCat()
            {
                Categories = db.Categories.OrderByDescending(cat => cat.Id).Take(5).ToList(),
                Products = db.Products.OrderBy(prod => prod.OrderBy).ToList()
            };
            return View(model);
        }
    }
}