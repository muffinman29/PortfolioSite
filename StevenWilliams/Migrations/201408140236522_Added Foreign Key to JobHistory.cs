namespace StevenWilliams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeytoJobHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "JobHistory_ID", c => c.Int());
            CreateIndex("dbo.Skills", "JobHistory_ID");
            AddForeignKey("dbo.Skills", "JobHistory_ID", "dbo.JobHistory", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "JobHistory_ID", "dbo.JobHistory");
            DropIndex("dbo.Skills", new[] { "JobHistory_ID" });
            DropColumn("dbo.Skills", "JobHistory_ID");
        }
    }
}
