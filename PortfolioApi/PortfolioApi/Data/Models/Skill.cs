using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Data.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string Percent { get; set; }
    }
}
