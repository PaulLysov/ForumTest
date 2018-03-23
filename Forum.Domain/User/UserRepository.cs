using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Base;
using Forum.Domain.User.Roles;

namespace Forum.Domain.User
{
	public class UserRepository:BaseEntityRepository<UserProfile>
	{
		public UserRepository(UnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
		/// <summary>
		/// Get user right by user id
		/// </summary>
		/// <param name="userId">user id</param>
		/// <returns>List right user </returns>
		public List<UserRights> GetUserRights(int userId)
		{
			return DataContext.Users.Where(x => x.Id == userId).SelectMany(x => x.Role.RoleRights).Select(t => t.Right).ToList();
		}

		/// <summary>
		/// get user role id 
		/// </summary>
		/// <param name="userId">user id</param>
		/// <returns>id role</returns>
		public int GetUserRoleId(int userId)
		{
			return DataContext.Users.Where(user => user.Id == userId).Select(user => user.RoleId).First();
		}

		public UserProfile GetByEmail(string email)
		{
			return DataContext.Users.FirstOrDefault(x => x.Email == email);
		}
	}
}
