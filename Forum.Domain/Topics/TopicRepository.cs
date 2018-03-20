using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Domain.Base;

namespace Forum.Domain.Topics
{
	public class TopicRepository:BaseEntityRepository<Topic>
	{
		public TopicRepository(UnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
