using System.Collections.Generic;

namespace Forum.Core.Models.Topics
{
	public class TopicsViewModel
	{
		public List<TopicItemViewModel> Topics { get; set; }
		public TopicFilter Filter { get;set; }
	}
}
