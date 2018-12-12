/* Alix Field
 * afield@cnm.edu
 * Provides a View that shows the owners Resume
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FieldP3_PersonalWebsite.Models;
using FieldP3_PersonalWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace FieldP3_PersonalWebsite.Controllers
{
    public class ResumeController : Controller
    {
        // Instanting a ApplicationDbContext Object
        private readonly ApplicationDbContext _context;

        // Creating the ResumeController Constructor
        // Passing the ADbC Object to the Constructor
        public ResumeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {   
            // Instantiating and Setting the ResumeViewModel Object and Properties
            ResumeViewModel rvm = new ResumeViewModel();
        
            rvm.EducationItems = _context.Educations.ToList();
            rvm.ExperienceItems = _context.Experiences.ToList();
            rvm.SkillItems = _context.Skills.ToList();
            rvm.Objective = "I want to develop your website!!";

            return View(rvm);
        } 
    }
}