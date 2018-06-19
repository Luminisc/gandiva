using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gandiva.Data;

namespace Gandiva.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<User> users = null;
            using (var context = new GandivaContext())
            {
                users = context.Users.ToList();
            }

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
    }
}