namespace Forum.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleRights",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        Right = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.Right })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 100),
                        Nickname = c.String(maxLength: 50),
                        RoleId = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        CreationDateTime = c.DateTime(nullable: false),
                        LastLoginDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TopicMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        Message = c.String(maxLength: 255),
                        UserId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        EditedDateTime = c.DateTime(),
                        ModeratedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.TopicId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeId = c.Int(nullable: false),
                        CreatedUserId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedUserId, cascadeDelete: false)
                .ForeignKey("dbo.Dict_TopicTypes", t => t.TypeId, cascadeDelete: false)
                .Index(t => t.TypeId)
                .Index(t => t.CreatedUserId);
            
            CreateTable(
                "dbo.Dict_TopicTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TopicMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.TopicMessages", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "TypeId", "dbo.Dict_TopicTypes");
            DropForeignKey("dbo.Topics", "CreatedUserId", "dbo.Users");
            DropForeignKey("dbo.RoleRights", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Topics", new[] { "CreatedUserId" });
            DropIndex("dbo.Topics", new[] { "TypeId" });
            DropIndex("dbo.TopicMessages", new[] { "UserId" });
            DropIndex("dbo.TopicMessages", new[] { "TopicId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.RoleRights", new[] { "RoleId" });
            DropTable("dbo.Dict_TopicTypes");
            DropTable("dbo.Topics");
            DropTable("dbo.TopicMessages");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.RoleRights");
        }
    }
}
