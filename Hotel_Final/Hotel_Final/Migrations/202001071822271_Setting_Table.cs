namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setting_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Logo = c.Int(nullable: false),
                        Desc = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        GooglePlus = c.String(),
                        Instagram = c.String(),
                        Youtube = c.String(),
                        Locations = c.String(),
                        Phones = c.String(),
                        Email = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
