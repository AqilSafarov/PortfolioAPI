using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.ASkillDto
{
    public class ASkillGetDto
    {
        public List<SkillGetDtoItem> SkillGetDtoItems { get; set; }
        public int TotalCount { get; set; }
    }
    public class SkillGetDtoItem
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string Percent { get; set; }
    }
}
