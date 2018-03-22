using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Forum.Domain.Base;
using Forum.Domain.User.Roles;

namespace Forum.Domain.User
{
	public class UserProfile : BaseEntity//IdentityUser
	{
		//public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserProfile> manager, string authenticationType)
		//{
		//	// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
		//	var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
		//	// Add custom user claims here
		//	return userIdentity;
		//}

		public string Email { get; set; }
		public string Login { get; set; }

		public int RoleId { get; set; }
		public Role Role { get; set; }

		/// <summary>
		/// user is blocked
		/// </summary>
		public bool? LockoutEnabled { get;set; }

		#region personal info 
		[StringLength(50)]
		[DisplayName("Имя")]
		public string FirstName { get; set; }
		[StringLength(50)]
		[DisplayName("Фамилия")]
		public string LastName { get; set; }
		#endregion

		public DateTime CreationDateTime { get; set; }
		public DateTime? LastLoginDateTime { get; set; }
	}
}