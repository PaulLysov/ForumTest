using System;
using System.Data.Entity;
using System.Linq;

namespace Forum.Domain.Base
{
	/// <summary>
	/// Base repositiry by entity
	/// </summary>
	/// <typeparam name="TEntity">typi of entity</typeparam>
	public class BaseEntityRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly DataContext DataContext;

		public BaseEntityRepository(UnitOfWork unitOfWork)
		{
			DataContext = unitOfWork.DataContext;
		}

		/// <summary>
		/// getting query by entity
		/// </summary>
		public IQueryable<TEntity> GetQuery()
		{
			return DataContext.Set<TEntity>();
		}

		/// <summary>
		/// getting entity by id
		/// </summary>
		public TEntity GetById(int id)
		{
			var entity = DataContext.Set<TEntity>().Find(id);
			if (entity == null)
				throw new Exception($" Entity not found at Id = {id},  type = [ \"{typeof (TEntity).Name}\"]");

			return entity;
		}

		/// <summary>
		/// adding or updating entity from database
		/// need calling method SaveChanges()
		/// </summary>
		public void AddOrUpdate(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}

			var entry = DataContext.Entry(entity);

			if (entity.Id == 0)
			{
				entry.State = EntityState.Added;
			}
			else
			{
				if (entry.State != EntityState.Detached)
				{
					return;
				}

				var dbEntity = DataContext.Set<TEntity>().Find(entity.Id);

				if (dbEntity != null)
				{
					DataContext.Entry(dbEntity).CurrentValues.SetValues(entity);
				}
				else
				{
					entry.State = EntityState.Added;
				}
			}
		}

		/// <summary>
		/// Remove entity 
		/// need calling method SaveChanges()
		/// </summary>
		public void Delete(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}

			var entry = DataContext.Entry(entity);

			if (entry.State == EntityState.Detached)
			{
				throw new ArgumentException("entry.State == EntityState.Detached", "entity");
			}

			if (entity.Id == 0 || DataContext.Set<TEntity>().Find(entity.Id) == null)
			{
				throw new Exception($"Removable entity not found. Id = {entity.Id},  entity type = [ \"{typeof (TEntity).Name}\"]");
			}

			DataContext.Entry(entity).State = EntityState.Deleted;
		}

		/// <summary>
		/// Remove entity by id
		/// need calling method SaveChanges()
		/// </summary>
		public void Delete(int id)
		{
			DataContext.Entry(GetById(id)).State = EntityState.Deleted;
		}
	}
}
