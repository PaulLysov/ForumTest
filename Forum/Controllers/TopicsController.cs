using System.Web.Mvc;

namespace Forum.Controllers
{
	public class TopicsController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Topics";

			return View();
		}

		public ActionResult Topic(int id)
		{
			return View(id);
		}
	}
}
