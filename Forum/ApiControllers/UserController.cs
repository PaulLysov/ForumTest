﻿using System.Collections.Generic;
using System.Web.Http;

namespace Forum.ApiControllers
{
	[Authorize]
	[RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET: api/User
		[Route("UserInfo")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}