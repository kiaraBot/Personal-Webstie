/* Alix Field
 * afield@cnm.edu
 * Provides a View that Connects User to PayPal 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FieldP3_PersonalWebsite.Controllers
{
    public class PayPalPaymentController : Controller
    {
        public IActionResult PPPaymentIndex()
        {
            ViewBag.Message = "Make a Payment with PayPal";
            return View();
        }
    }
}