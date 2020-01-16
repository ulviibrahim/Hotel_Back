namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        OrderCount = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderHistories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderHistories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OrderHistories", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.OrderHistories", new[] { "ProductId" });
            DropTable("dbo.OrderHistories");
        }
    }
}
