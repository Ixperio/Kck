namespace KasynoGui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RuletkaBets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        number = c.Int(),
                        IdZakldu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RuletkaBets");
        }
    }
}
