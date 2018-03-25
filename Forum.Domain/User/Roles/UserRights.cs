namespace Forum.Domain.User.Roles
{
	public enum UserRights
	{
		Unknown = 0,

		#region forum 
		[RightDetails(Description = "Создание разделов", Category = "Разделы")]
		SectionCreate = 1,
		[RightDetails(Description = "Удаление разделов", Category = "Разделы")]
		SectionRemove = 2,
		[RightDetails(Description = "Создание тем", Category = "Темы")]
		TopicCreate = 3,
		[RightDetails(Description = "Удаление тем", Category = "Темы")]
		TopicRemove = 4,
		[RightDetails(Description = "Message moderate", Category = "Сообщения")]
		MessageModerate = 5,

		#endregion forum

		#region users

		[RightDetails(Description = "User create", Category = "Users")]
		UserCreating = 6,
		[RightDetails(Description = "User edit", Category = "Users")]
		UserEditing = 7,
		[RightDetails(Description = "User blocked", Category = "Users")]
		UserBlocking = 8,

		[RightDetails(Description = "Сan see the list of users", Category = "Users")]
		UserListShow = 9,

		#endregion users
	}
}