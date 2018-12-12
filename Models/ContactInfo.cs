/* Alix Field
 * afield@cnm.edu
 * Contact Info Database Table Model
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldP3_PersonalWebsite.Models
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public string TypeOfRequest { get; set; }
        // Drop Down Menu
            // Quote
            // General Question
        public bool IsPhoneApp { get; set; }
        public bool IsWebApp { get; set; }
        public bool IsWindowApp { get; set; }
    }
}
