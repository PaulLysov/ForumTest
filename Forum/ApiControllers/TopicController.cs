using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Forum.Core.Models.Topics;
using Forum.Core.Services;
using WebMatrix.WebData;

namespace Forum.ApiControllers
{
	public class TopicController : ApiController
	{
		[HttpGet]
		[ActionName("GetTopicsByFilter")]
		[ResponseType(typeof(List<TopicItemViewModel>))]
		public async Task<IHttpActionResult> GetTopicsByFilter(TopicFilter filter)
		{
			filter = filter ?? new TopicFilter();
			var topics = new TopicService().GetTopicsByFilter(filter);
			return Ok(topics);
		}
	}
}
