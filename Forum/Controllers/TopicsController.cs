using System.Web.Mvc;
using Forum.Attributes;
using Forum.Core.Services;
using Forum.Domain.User.Roles;
using WebMatrix.WebData;

namespace Forum.Controllers
{
	[Authorize]
	public class TopicsController : Controller
	{
		[AllowAnonymous]
		public ActionResult Index()
		{
			ViewBag.Title = "Topics";

			return View();
		}

		[HttpPost]
		public ActionResult AddTopic(string name, string message)
		{
			var newTopic = new TopicService().AddNewTopic(name, message);
			if( newTopic == null )
				return Json(new {error = "Error at new topic added"});

			return Json(newTopic);
		} 
	}
}
