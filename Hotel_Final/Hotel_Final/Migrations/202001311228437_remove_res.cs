namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_res : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestorantProducts", "CategoryResId", "dbo.CategoryRes");
            DropIndex("dbo.RestorantProducts", new[] { "CategoryResId" });
            DropTable("dbo.CategoryRes");
            DropTable("dbo.RestorantProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RestorantProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.String(),
                        ProductCount = c.Int(nullable: false),
                        CategoryResId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryRes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RestorantProducts", "CategoryResId");
            AddForeignKey("dbo.RestorantProducts", "CategoryResId", "dbo.CategoryRes", "Id", cascadeDelete: true);
        }
    }
}
