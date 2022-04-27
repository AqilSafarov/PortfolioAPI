using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.AEducationDto
{
    public class AEducationGetDto
    {
        public int Id { get; set; }
        public string StudtyArea { get; set; }
        public string NameOfEdu { get; set; }
        public string EduDesc { get; set; }
        public DateTime EduStartDate { get; set; }
        public string EduEndDate { get; set; }
    }
}
