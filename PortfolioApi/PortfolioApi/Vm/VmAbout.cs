using PortfolioApi.Api.Client.DTOs;
using PortfolioApi.Api.Client.DTOs.EducationDto;
using PortfolioApi.Api.Client.DTOs.PortfolioUserDto;
using PortfolioApi.Api.Client.DTOs.SkillDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Vm
{
    public class VmAbout
    {
       public PortUserAboutGetDto PortUserAboutGetDtos { get; set; }
        public List<WorkExperienceAboutGetDto> WorkAboutExperienceGetDtos { get; set; }
        public List<SkillAboutGetDto> SkillAboutGetDtos { get; set; }
        public List<EducationAboutDto> EducationAboutDtos { get; set; }
    }
}
