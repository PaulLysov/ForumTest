using Forum.Domain.User;
using Forum.Domain.User.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Domain.Base;
using Forum.Domain.Dictionary;
using Forum.Domain.Topics;

namespace Forum.Domain
{
	public sealed class DataContext : DbContext
	{
		public DataContext() : base("DefaultConnection") { }

		#region users
		public DbSet<UserProfile> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<RoleRight> RoleRights { get; set; }
		#endregion

		#region dictionaries
		//public DbSet<TopicType> TopicTypes { get; set; }
		#endregion

		#region forum
		public DbSet<Topic> Topics { get; set; }
		public DbSet<TopicMessage> TopicMessages { get; set; }
		#endregion

		/// <summary>
		/// Creating tables
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			#region Dictionaries
			modelBuilder.Types<BaseDictionaryItem>().Configure(type => type.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
			modelBuilder.Entity<TopicType>().ToTable("Dict_TopicTypes");
			#endregion

			#region Users
			modelBuilder.Entity<Role>().ToTable("Roles");

			modelBuilder.Entity<RoleRight>().ToTable("RoleRights");
			modelBuilder.Entity<RoleRight>().HasKey(it => new { it.RoleId, it.Right });
			modelBuilder.Entity<RoleRight>().HasRequired(it => it.Role).WithMany(it => it.RoleRights).HasForeignKey(it => it.RoleId);

			modelBuilder.Entity<UserProfile>().ToTable("Users");
			modelBuilder.Entity<UserProfile>().HasRequired(t => t.Role).WithMany(t => t.Users).HasForeignKey(t => t.RoleId);
			#endregion

			#region Topic
			modelBuilder.Entity<Topic>().ToTable("Topics");
			modelBuilder.Entity<Topic>().HasRequired(t => t.CreatedUser).WithMany().HasForeignKey(t => t.CreatedUserId);
			modelBuilder.Entity<Topic>().HasRequired(t => t.Type).WithMany().HasForeignKey(t => t.TypeId);

			modelBuilder.Entity<TopicMessage>().ToTable("TopicMessages");
			modelBuilder.Entity<TopicMessage>().HasRequired(t => t.User).WithMany().HasForeignKey(t => t.UserId);
			modelBuilder.Entity<TopicMessage>().HasRequired(t => t.Topic).WithMany(t => t.Messages).HasForeignKey(t => t.TopicId);
			#endregion
		}
	}
}
