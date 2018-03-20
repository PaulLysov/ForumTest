﻿using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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
		public IHttpActionResult GetTopics(TopicFilter filter)
		{
			var model = new TopicService().GetTopicsByFilter(filter);
			if (model == null)
				return this.BadRequest("Data not found");

			return this.Ok(model);
		}

		// POST: api/CreateTopic
		[ResponseType(typeof(int))]
		public IHttpActionResult CreateTopic(TopicItemViewModel topic)
		{
			var id = new TopicService().CreateNewTopic(topic);
			if (id < 0)
				return this.BadRequest("Topic not created");

			return this.Ok(id);
		}	
	}
}