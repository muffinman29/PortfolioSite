using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StevenWilliams.Models
{
    public class JobSkillXR
    {

        public int ID { get; set; }

        public JobHistory Job { get; set; }

        public Skill Skill { get; set; }
    }
}