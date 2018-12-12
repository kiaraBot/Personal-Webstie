/* Alix Field
 * afield@cnm.edu
 * CRUD Controller
 * Changed: [HttpPost] Create Method
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FieldP3_PersonalWebsite.Data;
using FieldP3_PersonalWebsite.Models;
using System.Net.Mail;
using System.Text;

namespace FieldP3_PersonalWebsite.Controllers
{
    public class ContactInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactInfos.ToListAsync());
        }

        // GET: ContactInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfos
                .FirstOrDefaultAsync(m => m.ContactInfoId == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // GET: ContactInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Success(ContactInfo contactInfo)
        {
            return View(contactInfo);
        }    

        // POST: ContactInfoes/Create
        // ---------------------------------------------------------
        // Code provided by Robert Garner @ https://robgarnerblog.wordpress.com/2016/07/29/mvc-contact-forms/ 
        // ---------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( ContactInfo contactInfo)
        {
            // This method sends the users contact and order information to the administrator or site owner
            if (ModelState.IsValid)
            {
                // Send email to notify administrator of new contact message 
                // Alix Field_10.31.18
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient client = new SmtpClient
                    {

                        // Gmail is the smtp client
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new System.Net.NetworkCredential("afield08@gmail.com", "T@t0rT0t232")
                    };

                    MailAddress from = new MailAddress(contactInfo.Email.ToString());

                    StringBuilder sb = new StringBuilder();
                    sb.Append("First Name: " + contactInfo.FirstName);
                    sb.Append(Environment.NewLine);

                    sb.Append("Last Name: " + contactInfo.LastName);
                    sb.Append(Environment.NewLine);

                    sb.Append("Email: " + contactInfo.Email);
                    sb.Append(Environment.NewLine);

                    sb.Append("Comments: ");
                    sb.Append(Environment.NewLine);

                    sb.Append(contactInfo.LastName);
                    sb.Append(Environment.NewLine);

                    msg.From = from;
                    msg.To.Add("afield08@gmail.com");
                    msg.Subject = "New Contact";
                    msg.IsBodyHtml = false;
                    msg.Body = sb.ToString();

                    client.Send(msg);

                    return View("Success");
                }
                catch (Exception)
                {
                    return View("Error");
                }
                //_context.Add(contactInfo);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View();
        }


        // GET: ContactInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }
            return View(contactInfo);
        }

        // POST: ContactInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactInfoId,FirstName,LastName,Email,Comments,TypeOfRequest,IsPhoneApp,IsWebApp,IsWindowApp")] ContactInfo contactInfo)
        {
            if (id != contactInfo.ContactInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInfoExists(contactInfo.ContactInfoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactInfo);
        }

        // GET: ContactInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfos
                .FirstOrDefaultAsync(m => m.ContactInfoId == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // POST: ContactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            _context.ContactInfos.Remove(contactInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfos.Any(e => e.ContactInfoId == id);
        }
    }
}
