using System.Web.Mvc;
using Forum.Attributes;
using Forum.Core.Helpers;
using Forum.Core.Models.Users;
using Forum.Core.Services;
using Forum.Domain.User.Roles;
using WebMatrix.WebData;

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

		[RightCheck(Rights = new [] { UserRights.UserEditing })]
		public ActionResult Edit()
		{
			return View();
		}

		[HttpGet]
		[RightCheck(Rights = new [] { UserRights.UserListShow })]
		public ActionResult GetUserList()
		{
			var users = new UserService().GetUsersByFilter();
			return Json(users);
		}

		[HttpPost]
		public ActionResult EditUserInfo(UserProfileViewModel user)
		{
			if (WebSecurity.CurrentUserId != user.Id && !UserHelper.UserRights.Contains(UserRights.UserEditing))
				return Json("your a not right editing user info");

			return Json(true);
		}

		[HttpPost]
		[RightCheck(Rights = new [] { UserRights.UserBlocking })]
		public ActionResult LockoutUser(int id, bool block)
		{
			return Json(new UserService().LockoutUser(id,block));
		}

	}
}