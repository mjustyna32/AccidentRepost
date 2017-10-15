using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccidentRepost.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetEvents(bool importantOnly = true)
        {
            eyewitEntities dbeyewitEntities = new eyewitEntities();
            var allEvents = dbeyewitEntities.events.ToList();
            if(importantOnly)
                RemoveUnnecessaryEvents(allEvents);
            var requestedEvents = allEvents.ToArray();
            string json = JsonConvert.SerializeObject(requestedEvents);
            return Json( json, JsonRequestBehavior.AllowGet);
        }

        private static void RemoveUnnecessaryEvents(List<events> allEvents)
        {
            foreach (events e in allEvents)
            {
                if ((bool)!e.important)
                {
                    allEvents.Remove(e);
                    RemoveUnnecessaryEvents(allEvents);
                    break;
                }
            }
        }

        [HttpPost]
        public string AddEvent(string message)
        {
            try
            {
                events newEvent = (events)JsonConvert.DeserializeObject<events>(message);
                var result = 0;
                using (var dbContext = new eyewitEntities())
                {
                    dbContext.events.Add(newEvent);
                    result = dbContext.SaveChanges();
                }

                return result.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [HttpPost]
        public ActionResult ChangeEventState(int id)
        {
            eyewitEntities eyewitContext = new eyewitEntities();
            try
            {
                events eventToUpdate = eyewitContext.events.Find(id);
                eventToUpdate.important = !eventToUpdate.important;
                eyewitContext.SaveChanges();
                return GetEvents();
            }catch(Exception e)
            {
                return Content("Change state error");
            }
        }

    }
}