namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixed_book : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "BookDate", c => c.DateTime(nullable: false));
        }
    }
}
