using System.Collections.Generic;
using System.Web.Http;

namespace Forum.Controllers
{
    public class TopicController : ApiController
    {
        // GET: api/Topic
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Topic/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Topic
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Topic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Topic/5
        public void Delete(int id)
        {
        }
    }
}
