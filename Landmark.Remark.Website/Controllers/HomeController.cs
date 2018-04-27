using System.Web.Mvc;

namespace Landmark.Remark.Website.Controllers
{
    /// <summary>
    /// MVC Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}