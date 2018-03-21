using Forum.Domain;
using Forum.Domain.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Forum
{
	// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

	public class ApplicationUserManager : UserManager<UserProfile>
	{
		public ApplicationUserManager(IUserStore<UserProfile> store)
			: base(store)
		{
		}

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			using (var unitOfWork = new UnitOfWork())
			{
				var manager = new ApplicationUserManager(new UserStore<UserProfile>(unitOfWork.DataContext));
				// Configure validation logic for usernames
				manager.UserValidator = new UserValidator<UserProfile>(manager)
				{
					AllowOnlyAlphanumericUserNames = false,
					RequireUniqueEmail = true
				};
				// Configure validation logic for passwords
				manager.PasswordValidator = new PasswordValidator
				{
					RequiredLength = 6,
					RequireNonLetterOrDigit = true,
					RequireDigit = true,
					RequireLowercase = true,
					RequireUppercase = true,
				};
				var dataProtectionProvider = options.DataProtectionProvider;
				if (dataProtectionProvider != null)
				{
					manager.UserTokenProvider = new DataProtectorTokenProvider<UserProfile>(dataProtectionProvider.Create("ASP.NET Identity"));
				}
				return manager;
			}


		}
	}
}
