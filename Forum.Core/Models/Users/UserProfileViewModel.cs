using Forum.Domain.User.Roles;

namespace Forum.Core.Models.Users
{
	public class UserProfileViewModel
	{
		public string Id { get;set; }
		public string Login { get;set; }
		public string Email { get;set; }

		public int RoleId { get;set; }
		public Role Role { get;set; }
	}
}

