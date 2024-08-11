namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_date_movie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "HeadingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "HeadingDate");
        }
    }
}
