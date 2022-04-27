using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Client.DTOs
{
    public class WorkExperienceAboutGetDto
    {
        public string ExpArea { get; set; }
        public string NameOfExp { get; set; }
        public string Desc { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
