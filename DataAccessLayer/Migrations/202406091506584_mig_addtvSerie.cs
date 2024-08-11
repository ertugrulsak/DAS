namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addtvSerie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TvSeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        Author = c.String(),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TvSeries", "WriterID", "dbo.Writers");
            DropIndex("dbo.TvSeries", new[] { "WriterID" });
            DropTable("dbo.TvSeries");
        }
    }
}
