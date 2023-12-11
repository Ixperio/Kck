namespace KasynoGui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ruletkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameString = c.String(),
                        number = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ruletkas");
        }
    }
}
