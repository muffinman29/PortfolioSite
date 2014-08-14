using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StevenWilliams.Models
{
    public class JobSkillXR
    {
        public int ID { get; set; }

        public virtual JobHistory Job { get; set; }

        public virtual Skill Skill { get; set; }
    }
}