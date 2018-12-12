/* Alix Field
 * afield@cnm.edu
 * Provides a View that show cases images and explination of owners projects
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FieldP3_PersonalWebsite.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult PortfolioIndex()
        {
            return View();
        }
    }
}