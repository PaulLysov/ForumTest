using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Domain.Base;

namespace Forum.Domain.Topics
{
	public class TopicMessageRepository:BaseEntityRepository<Topic>
	{
		public TopicMessageRepository(UnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

	}
}
