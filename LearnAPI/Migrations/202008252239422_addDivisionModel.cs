namespace LearnAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDivisionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.departments", t => t.DepartmenId, cascadeDelete: true)
                .Index(t => t.DepartmenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.divisions", "DepartmenId", "dbo.departments");
            DropIndex("dbo.divisions", new[] { "DepartmenId" });
            DropTable("dbo.divisions");
        }
    }
}
