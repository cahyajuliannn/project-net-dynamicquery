namespace LearnAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.departments");
        }
    }
}
