/* Alix Field
 * afield@cnm.edu
 * CRUD Controller
 * Deleted: Contact View
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FieldP3_PersonalWebsite.Models;
using FieldP3_PersonalWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace FieldP3_PersonalWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContext Context => _context;

        public IActionResult Index(ResumeViewModel rvm)
        {
            return View(rvm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
