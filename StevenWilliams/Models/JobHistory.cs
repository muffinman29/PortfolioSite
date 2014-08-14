namespace StevenWilliams.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobHistory")]
    public partial class JobHistory
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Company { get; set; }

        [Display(Name = "Experience")]
        [Range(0, 40)]
        public int YearsExperience { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public List<JobSkillXR> History_ID { get; set; }
    }
}
