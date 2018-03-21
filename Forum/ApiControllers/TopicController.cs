using System.Collections.Generic;
using System.Web.Http;
using Forum.Core.Models.Topics;
using Forum.Core.Services;

namespace Forum.ApiControllers
{
	public class TopicController : ApiController
	{
		// GET: api/Topic
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		//POST:
		[HttpPost]
		public TopicsViewModel GetTopicsByFilter(TopicFilter filter)
		{
			return new TopicService().GetTopicsByFilter(filter);
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
