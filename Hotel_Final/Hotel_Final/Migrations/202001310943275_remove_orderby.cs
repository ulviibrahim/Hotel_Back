namespace Hotel_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_orderby : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RestorantProducts", "OrderBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestorantProducts", "OrderBy", c => c.Int(nullable: false));
        }
    }
}
