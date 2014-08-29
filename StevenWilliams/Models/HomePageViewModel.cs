using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StevenWilliams.Models
{
    public class HomePageViewModel
    {
        public IList<JobHistory> JobHistories { get; set; }
        public IList<Skill> Skills { get; set; }
    }
}