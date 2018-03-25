using System;

namespace Forum.Core.Models.TopicMessages
{
	public class TopicMessageViewModel
	{
		public int Id { get; set; }
		public int TopicId { get; set; }
		public string Message { get; set; }
		public string User { get; set; }
		public string CreationDateTime { get; set; }
	}
}
