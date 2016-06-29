using CodeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTracker.Controllers
{
    public class LinkController : Controller
    {
        private CodeTrackerDBContext CTDB = new CodeTrackerDBContext();
        // GET: Link
        [HttpGet]
        public ActionResult NewLinkForm()
        {
            List<Topic> allTopics = CTDB.Topics.ToList();
            return View(allTopics);
        }
        [HttpPost]
        public ActionResult NewLinkForm(int topicID, string type, string address)
        {
            Link addedLink = new Link { TopicID = topicID, Type = type, Address = address };

            Topic currTopic = CTDB.Topics.Find(topicID);
            addedLink.Topic = currTopic;

            CTDB.Links.Add(addedLink);
            CTDB.SaveChanges();

            return View("NewLinkFeedback", addedLink);
        }
    }
}