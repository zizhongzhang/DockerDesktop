using System.Collections.Specialized;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using Aspose.Words.Fonts;

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
            var fontSettings = new FontSettings();
            var sources = fontSettings.GetFontsSources();
            var fonts = sources[0].GetAvailableFonts();

            var directory = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(directory);
            
            fontSettings.SetFontsFolders(new[] { "C:/Users/ZizhongZhang/Dev/DockerDesktop/Web.Framework/App_Data", "C:/Windows/Fonts" }, false);
            
            sources = fontSettings.GetFontsSources();
            
            var stringBuilder = new StringBuilder();
            foreach (var source in sources)
            {
                foreach (var font in source.GetAvailableFonts())
                {
                    stringBuilder.Append(font.FullFontName);
                    stringBuilder.AppendLine();
                }
            }

            ViewBag.Message = stringBuilder.ToString();
            return View();
        }
    }
}