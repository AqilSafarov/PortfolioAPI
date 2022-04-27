using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Client.DTOs;
using PortfolioApi.Api.Client.DTOs.EducationDto;
using PortfolioApi.Api.Client.DTOs.PortfolioUserDto;
using PortfolioApi.Api.Client.DTOs.SkillDto;
using PortfolioApi.Data;
using PortfolioApi.Data.Models;
using PortfolioApi.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AboutController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            VmAbout vmAbout = new VmAbout();

            PortfolioUser portfolioUser = await _context.PortfolioUsers.FirstOrDefaultAsync();

            vmAbout.PortUserAboutGetDtos = _mapper.Map<PortUserAboutGetDto>(portfolioUser);



            List<WorkExperience> experience = await _context.WorkExperiences.ToListAsync();

            vmAbout.WorkAboutExperienceGetDtos = _mapper.Map<List<WorkExperienceAboutGetDto>>(experience);


            List<Skill> skills = await _context.Skills.ToListAsync();
            
            vmAbout.SkillAboutGetDtos = _mapper.Map<List<SkillAboutGetDto>>(skills);

            List<Education> educations = await _context.Educations.ToListAsync();

            vmAbout.EducationAboutDtos = _mapper.Map<List<EducationAboutDto>>(educations);

            return Ok(vmAbout);
        }
    }
}
