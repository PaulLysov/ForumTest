using System;
using Forum.Domain.Base;
using Forum.Domain.Dictionary;
using Forum.Domain.User;

namespace Forum.Domain.Topics
{
	public class Topic : BaseEntity
	{
		public string Name { get; set; }

		public int TypeId { get; set; }
		public TopicType Type { get; set; }

		public int CreatedUserId { get; set; }
		public UserProfile CreatedUser { get; set; }

		public DateTime CreatedDateTime { get; set; }
	}
}