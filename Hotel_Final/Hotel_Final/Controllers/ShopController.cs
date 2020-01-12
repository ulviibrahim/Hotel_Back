using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Final.Controllers
{
    public class ShopController : BaseController
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult test(string s)
        {
            return Content(s);
        }

    }
}