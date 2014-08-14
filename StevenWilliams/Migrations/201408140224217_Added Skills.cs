namespace StevenWilliams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSkills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobHistory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 200),
                        YearsExperience = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Years = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
            DropTable("dbo.JobHistory");
        }
    }
}
