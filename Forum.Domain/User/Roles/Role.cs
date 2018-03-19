using System.Collections.Generic;
using Forum.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Forum.Domain.User.Roles
{
	public class Role : BaseEntity
	{
		[StringLength(50)]
		[DisplayName("Название")]
		public string Name { get; set; }

		[StringLength(50)]
		[DisplayName("Описание")]
		public string Description { get; set; }

		public List<UserProfile> Users { get; set; }

		public List<RoleRight> RoleRights { get; set; }

		/// <summary>
		/// for this users not changed role
		/// </summary>
		public static readonly RoleType[] UnreassignableRoles = { RoleType.Admin };

	}
}