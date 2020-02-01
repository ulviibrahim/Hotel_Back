namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_photo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RestorantProducts", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestorantProducts", "Photo", c => c.String());
        }
    }
}
