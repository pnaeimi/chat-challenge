namespace SimpleChatAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chat1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chats", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chats", "Created", c => c.DateTime(nullable: false));
        }
    }
}
