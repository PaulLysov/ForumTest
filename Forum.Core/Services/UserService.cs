using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Core.Models.Users;
using Forum.Domain.User;
using Forum.Domain.User.Roles;
using Serilog;

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
				Login = x.Login
			} ).ToList();
		}

		public UserProfile GetUserByEmail(string mail)
		{
			return new UserRepository(UnitOfWork).GetQuery().FirstOrDefault(x =>x.Email.Contains(mail));
		}

		public UserProfile GetUserById(int userId)
		{
			return new UserRepository(UnitOfWork).GetById(userId);
		}

		public void CreateUser(UserProfile user, RoleType roleType)
		{
			try
			{
				user.RoleId = (int) roleType;
				new UserRepository(UnitOfWork).AddOrUpdate(user);



				UnitOfWork.SaveChanges();
			}
			catch (Exception ex)
			{
				Log.Logger.Error(ex, "[UserService][CreateUser] Errors at create user");
				UnitOfWork.Dispose();
			}
			
		}
	}
}

