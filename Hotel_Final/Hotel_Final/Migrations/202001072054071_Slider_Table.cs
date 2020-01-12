namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slider_Table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sliders", "OrderBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "OrderBy", c => c.Int());
        }
    }
}
