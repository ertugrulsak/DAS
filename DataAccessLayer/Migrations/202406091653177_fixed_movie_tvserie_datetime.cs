namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixed_movie_tvserie_datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "HeadingDate", c => c.DateTime());
            AlterColumn("dbo.TvSeries", "HeadingDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TvSeries", "HeadingDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "HeadingDate", c => c.DateTime(nullable: false));
        }
    }
}
