using System.Web.Mvc;
using Forum.Attributes;
using Forum.Domain.User.Roles;

namespace Forum.Controllers
{
	[Authorize]
	[RoleCheck(Roles = new[] { RoleType.Admin, RoleType.Moderator })]
	public class UsersController : Controller
	{
		
		[RightCheck(Rights = new [] { UserRights.UserListShow })]
		public ActionResult List()
		{
			return View();
		}
	}
}