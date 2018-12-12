/* Alix Field
 * afield@cnm.edu
 * Experience Database Table Model
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldP3_PersonalWebsite.Models
{
    public class Experience
    {
        public int ExperienceID { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
    }
}
