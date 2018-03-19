using System;
using Forum.Domain.Base;
using Forum.Domain.User.Roles;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.User
{
	public class UserProfile : BaseEntity
	{
		[StringLength(100)]
		[DisplayName("Email")]
		public string Email { get; set; }
		[StringLength(50)]
		[DisplayName("Nickname")]
		public string Nickname { get; set; }

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