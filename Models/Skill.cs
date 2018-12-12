/* Alix Field
 * afield@cnm.edu
 * Skill Database Table Model
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldP3_PersonalWebsite.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
