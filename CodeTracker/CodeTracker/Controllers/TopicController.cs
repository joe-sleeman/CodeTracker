using CodeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTracker.Controllers
{
    public class TopicController : Controller
    {
        private CodeTrackerDBContext CTDB = new CodeTrackerDBContext();

        // GET: Topic
        [HttpGet]
        public ActionResult NewTopicForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewTopicForm(string name, string description, List<Link> links)
        {
            Topic addedTopic = new Topic { Name = name, Description = description, Links = links };
            CTDB.Topics.Add(addedTopic);
            CTDB.SaveChanges();

            return View("NewTopicFeedback", addedTopic);
        }

    }
}