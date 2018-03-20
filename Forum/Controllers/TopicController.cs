using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Forum.Core.Models.Topics;
using Forum.Core.Services;

namespace Forum.Controllers
{
	public class TopicController : ApiController
	{
		// GET: api/GetTopics
		[ResponseType(typeof(TopicsViewModel))]
		public async Task<IHttpActionResult> GetTopics(TopicFilter filter)
		{
			var model = new TopicService().GetTopicsByFilter(filter);
			if (model == null)
				return this.BadRequest("Data not found");

			return this.Ok(model);
		}
	}
}