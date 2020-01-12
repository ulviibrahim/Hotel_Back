using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Final.Models;


namespace Hotel_Final.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        public BaseController()
        {
            ViewBag.Setting = db.Settings.FirstOrDefault();
            

        }
    }
}