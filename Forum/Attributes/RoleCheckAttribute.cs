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
	public class RoleCheckAttribute : AuthorizeAttribute
	{
		public new RoleType[] Roles { get; set; }

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (httpContext == null)
				throw new ArgumentNullException(nameof(httpContext));

			var currentUserId = WebSecurity.CurrentUserId;
			if (currentUserId <= 0)
				return false;

			if (Roles == null || Roles.Length <= 0)
				return false;

			var userRoleId = UserHelper.UserRole;
			if (Roles.Any(roleId => userRoleId == roleId))
				return true;

			return false;
		}
	}
}