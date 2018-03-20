using System;

namespace Forum.Core.Models.Topics
{
	public class TopicItemViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int CountMessage { get; set; }

		public int TypeId { get; set; }
		public string TypeName { get; set; }

		public string LastMessageUserNickname { get; set; }
		public DateTime? LastMessageDateTime { get; set; }
	}
}
