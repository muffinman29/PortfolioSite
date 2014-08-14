namespace StevenWilliams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomethingChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobSkillXRs", name: "JobHistory_ID", newName: "Job_ID");
            RenameIndex(table: "dbo.JobSkillXRs", name: "IX_JobHistory_ID", newName: "IX_Job_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JobSkillXRs", name: "IX_Job_ID", newName: "IX_JobHistory_ID");
            RenameColumn(table: "dbo.JobSkillXRs", name: "Job_ID", newName: "JobHistory_ID");
        }
    }
}
