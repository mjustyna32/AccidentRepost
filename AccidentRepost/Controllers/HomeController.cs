using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        
        public string GetEvents()
        {

            eyewitEntities dbeyewitEntities = new eyewitEntities();

            string json = JsonConvert.SerializeObject(dbeyewitEntities.events.ToArray());

            return json;

        }

        public string AddEvent()
        {
            eyewitEntities dbEyewitEntity = new eyewitEntities();
            events newEvent = new events();
            newEvent.name = "added";
            newEvent.registered_date = DateTime.Now;
            dbEyewitEntity.events.Add(newEvent);
            var result = dbEyewitEntity.SaveChanges();
            return result.ToString();
        }



    }
}