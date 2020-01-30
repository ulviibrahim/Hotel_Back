using Hotel_Final.Models;
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
            ViewBag.Testimonial = db.Testimonials.OrderByDescending(s=>s.Date).Take(3).ToList();
            return View(Sliders);
        }
        public ActionResult Error()
        {
            return View();
        }
       
      
    }
}