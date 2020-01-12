namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Logo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Settings", "Logo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Settings", "Logo", c => c.Int(nullable: false));
        }
    }
}
