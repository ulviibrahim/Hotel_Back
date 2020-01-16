namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class at_last : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OrderHistories", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.OrderHistories", "ApplicationUserId");
            RenameColumn(table: "dbo.OrderHistories", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.OrderHistories", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.OrderHistories", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderHistories", new[] { "ApplicationUserId" });
            AlterColumn("dbo.OrderHistories", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.OrderHistories", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.OrderHistories", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderHistories", "ApplicationUser_Id");
        }
    }
}
