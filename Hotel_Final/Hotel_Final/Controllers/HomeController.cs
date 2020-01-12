using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Final.Controllers
{

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var Sliders= db.Sliders.OrderBy(o => o.OrderBy).ToList();
            return View(Sliders);
        }

       
      
    }
}