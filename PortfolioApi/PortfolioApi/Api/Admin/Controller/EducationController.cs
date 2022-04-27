using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.AEducationDto;
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
    public class EducationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EducationController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Education> educations = await _context.Educations.ToListAsync();

            List<AEducationGetDto> educationGetDtos = _mapper.Map<List<AEducationGetDto>>(educations);

            return Ok(educationGetDtos);

        }

        [HttpPost]
        public async Task<IActionResult> Create(AEducationCreateDto createDto)
        {
            Education education = _mapper.Map<Education>(createDto);

            await _context.AddAsync(education);
            await _context.SaveChangesAsync();

            return StatusCode(201, education.Id);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AEducationCreateDto aEducationCreateDto)
        {
            Education education = await _context.Educations.FirstOrDefaultAsync(x => x.Id == id);
            #region  Check404
            if (education == null)
                return NotFound();
            #endregion


            education.StudtyArea = aEducationCreateDto.StudtyArea;
            education.NameOfEdu = aEducationCreateDto.NameOfEdu;
            education.EduDesc = aEducationCreateDto.EduDesc;
            education.EduStartDate = aEducationCreateDto.EduStartDate;
            education.EduEndDate = aEducationCreateDto.EduEndDate;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Education education = await _context.Educations.FirstOrDefaultAsync(x => x.Id == id);

            #region Check404
            if (education == null)
                return NotFound();
            #endregion

            _context.Remove(education);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}
