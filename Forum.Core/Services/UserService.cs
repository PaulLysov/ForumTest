using System.Collections.Generic;
using System.Linq;
using Forum.Core.Models.Users;
using Forum.Domain.User;

namespace Forum.Core.Services
{
	public class UserService:ServiceBase
	{
		public List<UserProfileViewModel> GetUsersByFilter()
		{
			var query = new UserRepository(UnitOfWork).GetQuery();
			return query.Select(x => new UserProfileViewModel
			{
				Id = x.Id,
				RoleId = x.RoleId,
				Email = x.Email,
				Login = x.UserName
			} ).ToList();
		}
	}
}

