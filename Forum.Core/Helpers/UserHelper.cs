using System.Collections.Generic;
using System.Web;
using Forum.Domain;
using Forum.Domain.User;
using Forum.Domain.User.Roles;
using Microsoft.AspNet.Identity;

namespace Forum.Core.Helpers
{
	public static class UserHelper
	{
		#region Name of session parameters 
		private const string UserRightsSessionParameterName = "UserAvailableRights";
		private const string UserRoleSessionParameterName = "UserRole";
		
		#endregion

		#region bool loaded parameters into session 
		private static bool UserRightsLoaded => HttpContext.Current.Session[UserRightsSessionParameterName] != null;

		private static bool UserRoleLoaded => HttpContext.Current.Session[UserRoleSessionParameterName] != null;
		#endregion

		#region public parameters
		public static string CurrentUserLogin => HttpContext.Current.User.Identity.Name;
		public static string CurrentUserId => HttpContext.Current.User.Identity.GetUserId<string>();

		public static List<UserRights> UserRights => UserRightsLoaded ? (List<UserRights>) HttpContext.Current.Session[UserRightsSessionParameterName] : LoadUserRightsIntoSession();
		
		public static RoleType UserRole => UserRoleLoaded ? (RoleType) HttpContext.Current.Session[UserRoleSessionParameterName] : LoadUserRoleIntoSession();
		#endregion		

		#region private methods 
		private static List<UserRights> LoadUserRightsIntoSession()
		{
			using (var unitOfwork = new UnitOfWork())
			{
				var rights = new UserRepository(unitOfwork).GetUserRights(CurrentUserId);
				return (List<UserRights>) (HttpContext.Current.Session[UserRightsSessionParameterName] = rights);
			}
		}
		private static RoleType LoadUserRoleIntoSession()
		{
			var currentUserId = CurrentUserId;
			if (string.IsNullOrEmpty(CurrentUserId))
				return (RoleType) (-1);

			using (var unitOfWork = new UnitOfWork())
			{
				var role = (RoleType) new UserRepository(unitOfWork).GetUserRoleId(currentUserId);
				return (RoleType) (HttpContext.Current.Session[UserRoleSessionParameterName] = role);
			}
		}
#endregion
	}
}
