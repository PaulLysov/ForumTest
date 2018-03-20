using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Forum.Core.Models.Topics;
using Forum.Core.Models.Users;
using Forum.Core.Services;

namespace Forum.Controllers
{
	public class UsersController : ApiController
	{
		// GET: api/GetTopics
		[ResponseType(typeof(List<UserProfileViewModel>))]
		public async Task<IHttpActionResult> GetUsers()
		{
			var users = new UserService().GetUsersByFilter();
			return this.Ok(users);
		}

	}
}
