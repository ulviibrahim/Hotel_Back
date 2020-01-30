using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Final.Controllers
{
    public class OrdersController : BaseController
    {
        // GET: Orders
        [Authorize]
        public ActionResult OrderHistory()
        {
            
            if (User.IsInRole("admin"))
            {
                var adminslist = db.OrderHistories.OrderByDescending(ord => ord.CreatedDate).ToList();
                return View(adminslist);
            }

            var userid = User.Identity.GetUserId();

            var orders = db.OrderHistories.Where(order => order.ApplicationUserId == userid).ToList();

            return View(orders);
        }

    }
}