using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeTracker.Models
{
    public class Link
    {
        public int LinkID { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }

        public int? TopicID { get; set; }
        public virtual Topic Topic { get; set; }
    }
}