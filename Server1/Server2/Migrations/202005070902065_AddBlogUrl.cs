namespace QueueJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Queues", newName: "Groups");
            CreateTable(
                "dbo.QueueJs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Groups_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Groups_Id)
                .Index(t => t.Groups_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QueueJs", "Groups_Id", "dbo.Groups");
            DropIndex("dbo.QueueJs", new[] { "Groups_Id" });
            DropTable("dbo.QueueJs");
            RenameTable(name: "dbo.Groups", newName: "Queues");
        }
    }
}
