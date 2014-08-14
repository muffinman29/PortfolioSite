namespace StevenWilliams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateXRTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobHistory", "Skill_ID", "dbo.Skills");
            DropIndex("dbo.JobHistory", new[] { "Skill_ID" });
            CreateTable(
                "dbo.JobSkillXRs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobHistory_ID = c.Int(),
                        Skill_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.JobHistory", t => t.JobHistory_ID)
                .ForeignKey("dbo.Skills", t => t.Skill_ID)
                .Index(t => t.JobHistory_ID)
                .Index(t => t.Skill_ID);
            
            DropColumn("dbo.JobHistory", "Skill_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobHistory", "Skill_ID", c => c.Int());
            DropForeignKey("dbo.JobSkillXRs", "Skill_ID", "dbo.Skills");
            DropForeignKey("dbo.JobSkillXRs", "JobHistory_ID", "dbo.JobHistory");
            DropIndex("dbo.JobSkillXRs", new[] { "Skill_ID" });
            DropIndex("dbo.JobSkillXRs", new[] { "JobHistory_ID" });
            DropTable("dbo.JobSkillXRs");
            CreateIndex("dbo.JobHistory", "Skill_ID");
            AddForeignKey("dbo.JobHistory", "Skill_ID", "dbo.Skills", "ID");
        }
    }
}
