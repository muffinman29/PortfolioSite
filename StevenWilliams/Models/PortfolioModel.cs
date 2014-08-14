namespace StevenWilliams.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PortfolioModel : DbContext
    {
        public PortfolioModel()
            : base("name=MainModel")
        {
        }

        public virtual DbSet<JobHistory> JobHistories { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<JobSkillXR> JobSkillXRs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
