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

        public ActionResult GetEvents()
        {

            eyewitEntities dbeyewitEntities = new eyewitEntities();

            string json = JsonConvert.SerializeObject(dbeyewitEntities.events.ToArray());
            return Json( json, JsonRequestBehavior.AllowGet);

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

    }
}