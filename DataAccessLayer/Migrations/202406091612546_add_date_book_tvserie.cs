namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_date_book_tvserie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "HeadingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TvSeries", "HeadingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TvSeries", "HeadingDate");
            DropColumn("dbo.Books", "HeadingDate");
        }
    }
}
