using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Final.Controllers
{
    public class PaidController : BaseController
    {
        // GET: Paid
        public ActionResult Index()
        {
            var Product = db.Products.ToList();
            return View(Product);
        }
    }
}