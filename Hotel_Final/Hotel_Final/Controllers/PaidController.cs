using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            if (db.Products.Find(id).ProductCount<1)
            {
                return Json(new { status = 303, message = "Çox təəssüf bu məhsul hal-hazırda tükənib" }, JsonRequestBehavior.AllowGet);
            };

            var order = new OrderHistory();
            var userId = User.Identity.GetUserId();
            order.ProductId = id;
            order.OrderCount = count;
            order.ApplicationUserId = User.Identity.GetUserId();
            
            if (User.Identity.GetUserId() == null)
            {
                return Json(new { status = 432 }, JsonRequestBehavior.AllowGet);
            }
            order.CreatedDate.ToString("ddMMyyyy");
            db.OrderHistories.Add(order);
            if (db.Products.Find(id).Price != null)
            {
                var parsePrice = db.Products.Find(id).Price;
                order.TotalPrice = order.OrderCount * int.Parse(parsePrice);

            }
            else
            {
                order.TotalPrice.ToString("Ödənişsizdir");

            }
            db.Products.Find(id).ProductCount -= count;
            db.SaveChanges();
            
            return Json(new { status=200,id=order.Id},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SendOrder( string Email,string Subject)
        {


            if (Subject =="undefined")
            {
                return RedirectToAction("Login", "Account");
            }

            var orderId = int.Parse(Subject);
            Email = db.OrderHistories.Find(orderId).ApplicationUser.Email;




            var neworder = db.OrderHistories.Find(orderId);
           
            

            var body = "<p>Email From: {0} <br>Adi: {2} <br> Sayi: {1} <br> Qiymeti: {3} <br><br> Otel Nomresi: {4} </p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("ulviia@code.edu.az"));  // replace with valid value 
            message.From = new MailAddress(Email);  // replace with valid value
            message.Subject = "Yeni product";

            message.Body = string.Format(body, Email, neworder.OrderCount, neworder.Product.Name, neworder.TotalPrice,neworder.ApplicationUser.RoomNumber);
            message.IsBodyHtml = true;
            try
            {
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "hotelweb.93@gmail.com",  // replace with valid value
                        Password = "Hotel_123"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    smtp.Send(message);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                if(ex.Message== "Failure sending mail.")
                {
                    db.Products.Find(neworder.ProductId).ProductCount += db.OrderHistories.FirstOrDefault(f=>f.Id==orderId).OrderCount;
                    db.Users.Find(neworder.ApplicationUserId).PayBalance -= db.OrderHistories.FirstOrDefault(f => f.Id == orderId).TotalPrice;
                    db.OrderHistories.Remove(neworder);
                    db.SaveChanges();
                    return RedirectToAction("Error", "Home");
                    
                }
                throw;
            }

           
            
        }
        
        }
}