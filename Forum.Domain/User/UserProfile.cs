using System;
using System.Collections.Generic;
using Forum.Domain.Base;
using Forum.Domain.User.Roles;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Forum.Domain.User
{
	public class UserProfile : IdentityUser
	{
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserProfile> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}

		public Role Role { get; set; }
		public int RoleId { get; set; }

		#region personal info 
		[StringLength(50)]
		[DisplayName("Имя")]
		public string FirstName { get; set; }
		[StringLength(50)]
		[DisplayName("Фамилия")]
		public string LastName { get; set; }
		#endregion
		public DateTime CreationDateTime { get; set; }
		public DateTime LastLoginDateTime { get; set; }
	}
}