using System.Web.Mvc;

namespace Forum.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		[AllowAnonymous]
		public ActionResult Registration()
		{
			return View();
		}

		[AllowAnonymous]
		public ActionResult Login()
		{
			return View();
		}

	}
}