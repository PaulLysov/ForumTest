using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Core.Helpers;
using Forum.Domain.User.Roles;
using WebMatrix.WebData;

namespace Forum.Attributes
{
	public class RightCheckAttribute : AuthorizeAttribute
	{
		public UserRights Right { get; set; } = UserRights.Unknown;
		public UserRights[] Rights { get; set; }

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (httpContext == null)
				throw new ArgumentNullException(nameof(httpContext));

			var currentUserId = WebSecurity.CurrentUserId;
			if (currentUserId <= 0)
				return false;

			if (Right != UserRights.Unknown && UserHelper.IsCurrentUserHasRight(Right))
				return true;

			if (Rights != null && Rights.Any() && UserHelper.IsCurrentUserHasAnyRight(Rights))
				return true;

			return false;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Result = new ViewResult { ViewName = "~/Views/AdminEx/NotEnoughRights.cshtml" };
		}
	}
}