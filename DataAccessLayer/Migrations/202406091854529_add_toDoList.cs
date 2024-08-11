namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_toDoList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        WriterID = c.Int(nullable: false),
                        ToDoListDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoLists", "WriterID", "dbo.Writers");
            DropIndex("dbo.ToDoLists", new[] { "WriterID" });
            DropTable("dbo.ToDoLists");
        }
    }
}
