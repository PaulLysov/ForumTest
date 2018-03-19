namespace Forum.Domain
{
	using System;

	/// <summary>
	/// The class shares a single DataContext between several repositories
	/// </summary>
	public sealed class UnitOfWork : IDisposable
	{
		public readonly DataContext DataContext;

		public UnitOfWork()
		{
			DataContext = new DataContext();
		}

		/// <summary>
		/// Save changes at DB
		/// </summary>
		public void SaveChanges()
		{
			DataContext.SaveChanges();
		}

		public void Dispose()
		{
			DataContext.Dispose();
		}
	}
}