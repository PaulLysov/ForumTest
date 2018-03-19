using System;

namespace Forum.Domain.User.Roles
{
	public class RightDetailsAttribute : Attribute
	{
		public RightDetailsAttribute()
		{
			Category = string.Empty;
			Description = string.Empty;
		}

		public string Category { get; set; }
		public string Description { get; set; }

	}
}