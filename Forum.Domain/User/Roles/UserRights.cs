namespace Forum.Domain.User.Roles
{
	public enum UserRights
	{
		#region forum 
		[RightDetails(Description = "Создание разделов", Category = "Разделы")]
		SectionCreate = 0,
		[RightDetails(Description = "Удаление разделов", Category = "Разделы")]
		SectionRemove = 1,
		[RightDetails(Description = "Создание тем", Category = "Темы")]
		TopicCreate = 2,
		[RightDetails(Description = "Удаление тем", Category = "Темы")]
		TopicRemove = 3,
		[RightDetails(Description = "Просмотр сообщений не прошедщих модерацию", Category = "Сообщения")]
		MessageShowNotModerate = 4,
		[RightDetails(Description = "Модерация сообщений", Category = "Сообщения")]
		MessageModerate = 5,

		#endregion forum

		#region users

		[RightDetails(Description = "Создание пользователей", Category = "Пользователи")]
		UserCreating = 6,
		[RightDetails(Description = "Редактирование пользователей", Category = "Пользователи")]
		UserEditing = 7,
		[RightDetails(Description = "Удаление пользователей", Category = "Пользователи")]
		UserDeleting = 8,
		[RightDetails(Description = "Блокировка пользователей", Category = "Пользователи")]
		UserBlocking = 9,

		#endregion users
	}
}