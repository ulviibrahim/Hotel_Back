namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_Usertext : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderHistories", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.OrderHistories", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            AddColumn("dbo.OrderHistories", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderHistories", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderHistories", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderHistories", "ApplicationUserId");
            RenameIndex(table: "dbo.OrderHistories", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.OrderHistories", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
