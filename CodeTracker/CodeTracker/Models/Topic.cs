using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeTracker.Models
{
    public class Topic
    {
        public int TopicID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Link stuff

        public virtual List<Link> Links { get; set; }
    }
}