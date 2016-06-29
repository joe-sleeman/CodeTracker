using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeTracker.Models
{
    public class CodeTrackerDBContext :DbContext 
    {
        public DbSet<Link> Links { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }

    public class AllDataContainer
    {
        public List<Link> allLinks { get; set; }
        public List<Topic> allTopics { get; set; }
    }
}