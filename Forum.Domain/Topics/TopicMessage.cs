using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Forum.Domain.Base;
using Forum.Domain.User;

namespace Forum.Domain.Topics
{
	public class TopicMessage:BaseEntity
	{
		public int TopicId { get; set; }
		public Topic Topic { get; set; }

		[StringLength(255)]
		public string Message { get; set; }

		public int UserId { get; set; }
		public UserProfile User { get; set; }

		public DateTime CreateDateTime { get; set; }
		public DateTime? EditDateTime { get; set; }
		public DateTime? ModerateDateTime { get; set; }
	}
}