using Forum.Domain;

namespace Forum.Core.Services
{
	public abstract class ServiceBase
	{
		//use at logger
		private string _currentClassName;

		private UnitOfWork _unitOfWork;
		protected UnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = new UnitOfWork());

		protected ServiceBase() { /* empty */ }
		protected ServiceBase(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

		protected string CurrentClassName
		{
			get
			{
				if (string.IsNullOrEmpty(_currentClassName))
				{
					_currentClassName = GetType().Name;
				}
				return _currentClassName = GetType().Name;
			}
		}
	}
}