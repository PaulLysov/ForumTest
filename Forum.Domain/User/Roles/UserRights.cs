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
		[RightDetails(Description = "Просмотр сообщений не прошедщих модерацию", Category = "Сообщения")]
		MessageShowNotModerate = 5,
		[RightDetails(Description = "Модерация сообщений", Category = "Сообщения")]
		MessageModerate = 6,

		#endregion forum

		#region users

		[RightDetails(Description = "Создание пользователей", Category = "Users")]
		UserCreating = 7,
		[RightDetails(Description = "Редактирование пользователей", Category = "Users")]
		UserEditing = 8,
		[RightDetails(Description = "Удаление пользователей", Category = "Users")]
		UserDeleting = 9,
		[RightDetails(Description = "Блокировка пользователей", Category = "Users")]
		UserBlocking = 10,

		[RightDetails(Description = "Сan see the list of users", Category = "Users")]
		UserListShow = 11,

		#endregion users
	}
}