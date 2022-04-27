using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.AWorkExperience;
using PortfolioApi.Data;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.Controller
{
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class WorkExperienceController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public WorkExperienceController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<WorkExperience> workExperiences = await _context.WorkExperiences.ToListAsync();

            List<AWorkExperinceGetDto> socialGetDtos = _mapper.Map<List<AWorkExperinceGetDto>>(workExperiences);

            return Ok(socialGetDtos);

        }

        [HttpPost]
        public async Task<IActionResult> Create(AWorkExperienceCreateDto experienceCreateDto)
        {
            WorkExperience workExperiences = _mapper.Map<WorkExperience>(experienceCreateDto);

            await _context.AddAsync(workExperiences);
            await _context.SaveChangesAsync();

            return StatusCode(201, workExperiences.Id);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AWorkExperienceCreateDto aWorkExperienceCreateDto)
        {
            WorkExperience workExperiences = await _context.WorkExperiences.FirstOrDefaultAsync(x => x.Id == id);
            #region  Check404
            if (workExperiences == null)
                return NotFound();
            #endregion


            workExperiences.ExpArea = aWorkExperienceCreateDto.ExpArea;
            workExperiences.NameOfExp = aWorkExperienceCreateDto.NameOfExp;
            workExperiences.Desc = aWorkExperienceCreateDto.Desc;
            workExperiences.StartDate = aWorkExperienceCreateDto.StartDate;
            workExperiences.EndDate = aWorkExperienceCreateDto.EndDate;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            WorkExperience workExperiences = await _context.WorkExperiences.FirstOrDefaultAsync(x => x.Id == id);


            #region Check404
            if (workExperiences == null)
                return NotFound();
            #endregion

            _context.Remove(workExperiences);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}
