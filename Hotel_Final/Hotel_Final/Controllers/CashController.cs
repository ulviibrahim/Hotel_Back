using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Final.Models;

namespace Hotel_Final.Controllers
{
    public class CashController : BaseController
    {


        public ActionResult Index(int id)
        {

            var ProductsList = db.Products.FirstOrDefault(product => product.Id == id);
              //var ProductsList = db.Products.Where(p => products.Contains(p.Name)).ToList();

            return View(ProductsList
                );
        }

    }
}