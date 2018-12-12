using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldP3_PersonalWebsite.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string EntryTitle { get; set; }
        public string EntryDesc { get; set; }
        public string EntryContent { get; set; }
    }
}
