using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_Final.Models;
using Microsoft.AspNet.Identity;

namespace Hotel_Final.Controllers
{
    public class CashController : BaseController
    {


        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var model = db.Users.Find(userId);
            
           return View(model);
        }
        [HttpPost]
        public JsonResult CashOnline(string TotalPrice)
        {
            var total = int.Parse(TotalPrice);
            if (total == 0)
            {
                return Json(new
                {
                    status = 404,
                    message = "Eded duzgun deyildir"
                }, JsonRequestBehavior.AllowGet);
            }
            var userId = User.Identity.GetUserId();

            db.Users.Find(userId).PayBalance -= total;
           var isdeletedtrue= db.Users.Find(userId).OrderHistories.Where(s => s.isDeleted==false);
            foreach (var order in isdeletedtrue)
            {
                order.isDeleted = true;
            }
            db.SaveChanges();
            return Json( new { status = 200, message = "Ödəniş uğurla həyata keçirildi" });
        }


    }
}