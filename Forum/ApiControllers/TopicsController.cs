using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Forum.Core.Models.Topics;
using Forum.Core.Services;
using WebMatrix.WebData;

namespace Forum.ApiControllers
{
	[Authorize]
	public class TopicsController : ApiController
	{
		// GET: api/Topic
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		[AllowAnonymous]
		[Route("GetTopicsByFilter")]
		[ResponseType(typeof(TopicsViewModel))]
		public async Task<IHttpActionResult>  GetTopicsByFilter(TopicFilter filter)
		{
			return Ok(new TopicService().GetTopicsByFilter(filter));
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
