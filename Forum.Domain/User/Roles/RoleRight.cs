namespace Forum.Domain.User.Roles
{
	public class RoleRight
	{
		public Role Role { get; set; }
		public int RoleId { get; set; }
		public UserRights Right { get; set; }
	}
}