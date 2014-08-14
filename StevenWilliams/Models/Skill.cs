using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace StevenWilliams.Models
{
    [Table("Skills")]
    public partial class Skill
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Years { get; set; }

        public virtual List<JobSkillXR> Skill_ID { get; set; }
    }
}