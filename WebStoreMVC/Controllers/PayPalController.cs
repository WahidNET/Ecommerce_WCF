using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebStoreMVC.Models;

namespace WebStoreMVC.Controllers
{
    public class PayPalController : Controller
    {
        public ActionResult ValidateCommand(string product, string totalPrice)
        {
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPal(useSandbox);

            paypal.item_name = product;
            paypal.amount = totalPrice;
            return View(paypal);
        }

        public ActionResult RedirectFromPaypal()
        {
            return View();
        }

        public ActionResult CancelFromPaypal()
        {
            return View();
        }

        public ActionResult NotifyFromPaypal()
        {
            return View();
        }
    }
}