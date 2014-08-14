namespace StevenWilliams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "JobHistory_ID", "dbo.JobHistory");
            DropIndex("dbo.Skills", new[] { "JobHistory_ID" });
            AddColumn("dbo.JobHistory", "Skill_ID", c => c.Int());
            CreateIndex("dbo.JobHistory", "Skill_ID");
            AddForeignKey("dbo.JobHistory", "Skill_ID", "dbo.Skills", "ID");
            DropColumn("dbo.Skills", "JobHistory_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "JobHistory_ID", c => c.Int());
            DropForeignKey("dbo.JobHistory", "Skill_ID", "dbo.Skills");
            DropIndex("dbo.JobHistory", new[] { "Skill_ID" });
            DropColumn("dbo.JobHistory", "Skill_ID");
            CreateIndex("dbo.Skills", "JobHistory_ID");
            AddForeignKey("dbo.Skills", "JobHistory_ID", "dbo.JobHistory", "ID");
        }
    }
}
