using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Core.Models.Users;
using Forum.Domain.User;
using Forum.Domain.User.Roles;
using Microsoft.AspNet.Identity.EntityFramework;

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

		public UserProfile GetUserByEmail(string mail)
		{
			return new UserRepository(UnitOfWork).GetQuery().FirstOrDefault(x =>x.Email.Contains(mail));
		}

		public IdentityUser GetUserById(string userId)
		{
			return new UserRepository(UnitOfWork).GetById(userId);
		}
	}
}

