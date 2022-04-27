using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Client.DTOs.EducationDto
{
    public class EducationAboutDto
    {
        public string StudtyArea { get; set; }
        public string NameOfEdu { get; set; }
        public string EduDesc { get; set; }
        public DateTime EduStartDate { get; set; }
        public string EduEndDate { get; set; }
    }
}
