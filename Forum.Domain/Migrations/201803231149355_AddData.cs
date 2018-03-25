namespace Forum.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddData : DbMigration
    {
        public override void Up()
        {
			Sql("Insert into Roles (Name,Description) Values('Admin', 'Admin')");
			Sql("Insert into Roles (Name,Description) Values('Moderator', 'Moderator')");
			Sql("Insert into Roles (Name,Description) Values('User', 'User')");

			Sql("Insert into Dict_TopicTypes (Name) Values('Default theme')");
        }

        public override void Down()
        {
        }
    }
}
