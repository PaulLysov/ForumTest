using System.Data.Entity.Migrations;
using System.Linq;
using Forum.Domain.Base;

namespace Forum.Domain.Dictionary
{
	public sealed class DictionaryRepository
	{
		private readonly DataContext _dataContext;

		public DictionaryRepository(UnitOfWork unitOfWork)
		{
			_dataContext = unitOfWork.DataContext;
		}

		public IQueryable<T> GetQuery<T>() where T : BaseDictionaryItem
		{
			return _dataContext.Set<T>();
		}

		public int AddNew<T>(T item) where T : BaseDictionaryItem
		{
			_dataContext.Set<T>().Add(item);
			_dataContext.SaveChanges();

			return item.Id;
		}

		public void Delete<T>(int id) where T : BaseDictionaryItem
		{
			var set = _dataContext.Set<T>();
			var item = set.Find(id);

			if(item == null)
				return;
			set.Remove(item);
		}

		public int Update<T>(T entity) where T : BaseDictionaryItem
		{
			var set = _dataContext.Set<T>();
			set.AddOrUpdate(entity);
			_dataContext.SaveChanges();

			return entity.Id;
		}
	}
}
