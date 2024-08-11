namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_fixed_book : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "HeadingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "HeadingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "BookDate");
        }
    }
}
