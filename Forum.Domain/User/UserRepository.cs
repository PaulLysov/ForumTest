using System.Collections.Generic;
using System.Linq;
using Forum.Domain.User.Roles;

namespace Forum.Domain.User
{
	public class UserRepository
	{
		protected readonly DataContext DataContext;
		public UserRepository(UnitOfWork unitOfWork)
		{
			DataContext = unitOfWork.DataContext;
		}

		public IQueryable<UserProfile> GetQuery()
		{
			return DataContext.Set<UserProfile>();
		}

		/// <summary>
		/// Get user right by user id
		/// </summary>
		/// <param name="userId">user id</param>
		/// <returns>List right user </returns>
		public List<UserRights> GetUserRights(string userId)
		{
			return DataContext.Users.Where(x => x.Id == userId).SelectMany(x => x.Role.RoleRights).Select(t => t.Right).ToList();
		}

		/// <summary>
		/// get user role id 
		/// </summary>
		/// <param name="userId">user id</param>
		/// <returns>id role</returns>
		public int GetUserRoleId(string userId)
		{
			return DataContext.Users.Where(user => user.Id == userId).Select(user => user.RoleId).First();
		}

		/// <summary>
		/// Get user by id
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public UserProfile GetById(string userId)
		{
			return DataContext.Users.FirstOrDefault(x => x.Id == userId);
		}
	}
}
