using System;
using System.Net;
using System.Web.Mvc;
using Forum.Core.Helpers;
using Forum.Core.Models;
using Forum.Core.Services;
using Forum.Domain.User.Roles;
using Serilog;
using WebMatrix.WebData;
using LoginBindingModel = Forum.Core.Models.LoginBindingModel;

namespace Forum.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		[System.Web.Mvc.AllowAnonymous]
		public ActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Register(RegisterBindingModel model)
		{
			try
			{
				if (!ModelState.IsValid)
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest,  "Data is not a valid");

				//create user
				if (new UserService().CreateUser(model, RoleType.User))
				{
					WebSecurity.CreateAccount(model.Email, model.Password);
					return new HttpStatusCodeResult(HttpStatusCode.OK);
				}

				return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User is not created.");
					
			}
			catch (Exception ex)
			{
				Log.Logger.Error(ex, "[AccountController][Register] Errors at user registration");
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
			}
		}

		[AllowAnonymous]
		public ActionResult Login()
		{
			return View();
		}

		
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Login(LoginBindingModel model)
		{
			if (!ModelState.IsValid || !WebSecurity.Login(model.Email, model.Password, model.RememberMe))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Login failed" );

			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		public ActionResult Logout()
		{
			UserHelper.ResetCurrentUserSessionData();
			WebSecurity.Logout();
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

	}
}