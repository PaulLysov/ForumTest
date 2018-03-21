using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Core.Helpers;
using Forum.Core.Models.Topics;
using Forum.Domain.Topics;
using Forum.Domain.User;
using Newtonsoft.Json;
using Serilog;

namespace Forum.Core.Services
{
	public class TopicService : ServiceBase
	{
		public int CreateNewTopic(TopicItemViewModel data)
		{
			try
			{
				var user = new UserRepository(UnitOfWork).GetById(UserHelper.CurrentUserId);
				if (user == null)
					throw new Exception("User not found!");

				var newTopic = new Topic
				{
					CreatedDateTime = DateTime.Now,
					Name = data.Name,
					TypeId = data.TypeId,
					CreatedUserId = UserHelper.CurrentUserId
				};

				new TopicRepository(UnitOfWork).AddOrUpdate(newTopic);
				UnitOfWork.SaveChanges();

				return newTopic.Id;
			}
			catch (Exception ex)
			{
				Log.Logger.Error(ex,$"[TopicService][CreateNewTopic] Error at create new topic. data inputted  = [{JsonConvert.SerializeObject(data)}]");
				return -1;
			}
		}

		public TopicsViewModel GetTopicsByFilter(TopicFilter filter)
		{
			var query = new TopicRepository(UnitOfWork).GetQuery();
			if (!string.IsNullOrEmpty(filter.TopicName))
				query = query.Where(x => x.Name.Contains(filter.TopicName));

			if (filter.TopicType.HasValue)
				query = query.Where(x => x.TypeId == filter.TopicType.Value);

			return new TopicsViewModel
			{
				Filter = filter,
				Topics = query.Select(x => new TopicItemViewModel
				{
					Id = x.Id,
					Name = x.Name,
					TypeName = x.Type.Name,
					CountMessage = x.Messages.Count,
					LastMessageDateTime = x.Messages.OrderByDescending(m => m.CreateDateTime).Select(m => m.CreateDateTime).FirstOrDefault(),
					LastMessageUserLogin = x.Messages.OrderByDescending(m => m.CreateDateTime).Select(m => m.User.Login).FirstOrDefault()
				}).ToList()
			};
		}

	}
}