using System.Collections.Specialized;
using System;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace Web.Framework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new System.Uri(ConfigurationManager.AppSettings["APIService"])
            };
            var response = httpClient.GetStringAsync("home").Result;
            ViewBag.Message = response;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = ConfigurationManager.AppSettings["complex:setting2"];

            return View();
        }
    }
}