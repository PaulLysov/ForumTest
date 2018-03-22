using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Forum.Core.Models.Topics;
using Forum.Core.Services;
using WebMatrix.WebData;

namespace Forum.ApiControllers
{
	[Authorize]
	public class TopicController : ApiController
	{
		// GET: api/Topic
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		//POST:
		[HttpPost]
		[AllowAnonymous]
		[Route("GetTopicsByFilter")]
		public TopicsViewModel GetTopicsByFilter(TopicFilter filter)
		{
			return new TopicService().GetTopicsByFilter(filter);
		}

		[HttpPost]
		[Route("AddTopic")]
		public async Task<IHttpActionResult> AddTopic([FromBody]TopicItemViewModel model)
		{
			if (!WebSecurity.IsAuthenticated)
				return BadRequest("Not authorized");

			if(new TopicService().AddTopic(model))
					return BadRequest("Error at new topic added");

			return Ok();
		} 
	}
}
