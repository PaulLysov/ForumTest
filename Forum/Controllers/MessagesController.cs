using System.Linq;
using System.Web.Mvc;
using Forum.Core.Models.TopicMessages;
using Forum.Core.Services;

namespace Forum.Controllers
{
	[Authorize]
	public class MessagesController : Controller
	{
		[AllowAnonymous]
		[HttpGet]
		public ActionResult ShowTopic(int id)
		{
			var messages = new TopicService().GetMessagesByTopicId(id).Select(x => new TopicMessageViewModel
			{
				Id = x.Id,
				TopicId = x.TopicId,
				User = x.User.Login,
				CreationDateTime = x.CreateDateTime.ToShortDateString(),
				Message = x.Message
			}).ToList();
			return Json(messages);
		}

		[HttpPost]
		public ActionResult AddTopic(string name, string message)
		{
			var newTopic = new TopicService().AddNewTopic(name, message);
			if( newTopic == null )
				return Json(new {error = "Error at new topic added"});

			return Json(newTopic);
		} 
	}
}
