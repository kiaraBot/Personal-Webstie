using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldP3_PersonalWebsite.Models
{
    public class ResumeViewModel
    {
        public List<Education> EducationItems { get; set; }
        public List<Experience> ExperienceItems { get; set; }
        public List<Skill> SkillItems { get; set; }
        public string Objective { get; set; }
    }
}
