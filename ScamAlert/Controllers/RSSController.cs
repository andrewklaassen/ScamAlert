using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ScamAlert.Models;

namespace ScamAlert.Controllers
{
    public class RSSController : Controller
    {
        // GET: RSS
        public ActionResult Index()
        {
            XmlDocument xmlDoc = new XmlDocument();
            string url = "https://www.consumer.ftc.gov/blog/rss";
            xmlDoc.Load(url);
            XmlElement rss = xmlDoc.DocumentElement;
            XmlNode channel = rss.FirstChild;
            XmlNodeList childNodes = channel.ChildNodes;
            List<XmlNode> cNS = new List<XmlNode>();
            foreach (XmlNode temp in childNodes)
            {
                cNS.Add(temp);
            }
            var model = new ChildNodes
            {
                childNodes = cNS
            };
            List<ChildNodes> cn = new List<ChildNodes>();
            cn.Add(model);
            return View(cn);
        }

        private static List<string> GetRssFeeds()
        {
            List<string> feeds = new List<string>();

            feeds.Add("https://www.consumer.ftc.gov/blog/rss");

            return feeds;
        }
    }
}