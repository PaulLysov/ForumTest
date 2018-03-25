using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Core.Helpers;
using Forum.Core.Models.TopicMessages;
using Forum.Core.Models.Topics;
using Forum.Domain.Dictionary;
using Forum.Domain.Topics;
using Forum.Domain.User;
using Forum.Domain.User.Roles;
using Newtonsoft.Json;
using Serilog;
using WebMatrix.WebData;

namespace Forum.Core.Services
{
	public class TopicService : ServiceBase
	{
		//public int CreateNewTopic(TopicItemViewModel data)
		//{
		//	try
		//	{
		//		var currentUserId = WebSecurity.CurrentUserId;
		//		var user = new UserRepository(UnitOfWork).GetById(currentUserId);
		//		if (user == null)
		//			throw new Exception("User not found!");

		//		var newTopic = new Topic
		//		{
		//			CreatedDateTime = DateTime.Now,
		//			Name = data.Name,
		//			TypeId = data.TypeId,
		//			CreatedUserId = currentUserId
		//		};

		//		new TopicRepository(UnitOfWork).AddOrUpdate(newTopic);
		//		UnitOfWork.SaveChanges();

		//		return newTopic.Id;
		//	}
		//	catch (Exception ex)
		//	{
		//		Log.Logger.Error(ex,$"[TopicService][CreateNewTopic] Error at create new topic. data inputted  = [{JsonConvert.SerializeObject(data)}]");
		//		return -1;
		//	}
		//}

		public List<TopicItemViewModel> GetTopicsByFilter(TopicFilter filter)
		{
		var query = new TopicRepository(UnitOfWork).GetQuery();
			if (!string.IsNullOrEmpty(filter.TopicName))
				query = query.Where(x => x.Name.Contains(filter.TopicName));

			if (filter.TopicType.HasValue)
				query = query.Where(x => x.TypeId == filter.TopicType.Value);

			return query.Select(x => new TopicItemViewModel
			{
				Id = x.Id,
				Name = x.Name,
				TypeName = x.Type.Name,
				CountMessage = x.Messages.Count,
				LastMessageDateTime =
					x.Messages.OrderByDescending(m => m.CreateDateTime).Select(m => m.CreateDateTime).FirstOrDefault(),
				LastMessageUserLogin =
					x.Messages.OrderByDescending(m => m.CreateDateTime).Select(m => m.User.Login).FirstOrDefault()
			}).ToList();
		}

		public TopicItemViewModel AddNewTopic(string name, string message)
		{
			try
			{
				var currentUserId = WebSecurity.CurrentUserId;

				//create topic
				var entity = new Topic
				{
					CreatedDateTime = DateTime.Now,
					CreatedUserId = currentUserId,
					Name = name,
					TypeId = GetDefaultTopicType()
				};

				new TopicRepository(UnitOfWork).AddOrUpdate(entity);
				UnitOfWork.SaveChanges();

				//create message 
				var newMessage = new TopicMessage
				{
					CreateDateTime = DateTime.Now,
					TopicId = entity.Id,
					UserId = currentUserId,
					Message =  message,
				};
				//moderate if has user right 
				if(UserHelper.UserRights.Contains(UserRights.MessageModerate))
					newMessage.ModerateDateTime = DateTime.Now;
				
				var messageRepo = new TopicMessageRepository(UnitOfWork);
				messageRepo.AddOrUpdate(newMessage);
				UnitOfWork.SaveChanges();

				var messages = messageRepo.GetQuery().Where(x => x.TopicId == entity.Id);

				return new TopicItemViewModel
				{
					Id =  entity.Id,
					Name = entity.Name,
					TypeId = entity.TypeId,
					CountMessage = entity.Messages.Count,
					LastMessageUserLogin = messages.OrderByDescending(x => x.CreateDateTime).Select(x => x.User.Login).FirstOrDefault(),
					LastMessageDateTime = messages.OrderByDescending(x => x.CreateDateTime).Select(x => x.CreateDateTime).FirstOrDefault()
				};
			}
			catch (Exception ex)
			{
				Log.Logger.Error(ex, $"[{CurrentClassName}][AddTopic] Errors at new topic added!");
				return null;
			}
			
		}

		private int GetDefaultTopicType()
		{
			return new DictionaryRepository(UnitOfWork).GetQuery<TopicType>().Select(x => x.Id).FirstOrDefault();
		}

		public List<TopicMessage> GetMessagesByTopicId(int topicId)
		{
			return new TopicMessageRepository(UnitOfWork).GetQuery().Where(x => x.TopicId == topicId).ToList();
		}
	}
}