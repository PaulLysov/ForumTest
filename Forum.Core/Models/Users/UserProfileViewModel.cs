using System;
using Forum.Domain.User.Roles;

namespace Forum.Core.Models.Users
{
	public class UserProfileViewModel
	{
		public int Id { get;set; }
		public string Login { get;set; }
		public string Email { get;set; }
		public int RoleId { get;set; }
		public Role Role { get;set; }

		public bool? LockoutEnabled { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		public DateTime CreationDateTime { get; set; }
		public DateTime? LastLoginDateTime { get; set; }
	}
}

