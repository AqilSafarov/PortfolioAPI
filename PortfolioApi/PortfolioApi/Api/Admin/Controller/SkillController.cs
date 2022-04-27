using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.ASkillDto;
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
    public class SkillController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SkillController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page=1)
        {
            List<Skill> skills = await _context.Skills.Skip((page - 1) * 8).Take(8).ToListAsync();
            ASkillGetDto skillGetDto = new ASkillGetDto
            {
                SkillGetDtoItems = _mapper.Map<List<SkillGetDtoItem>>(skills),
            };


            return Ok(skillGetDto);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ASkillCreateDto skillCreateDto)
        {
            Skill skill = _mapper.Map<Skill>(skillCreateDto);

            await _context.AddAsync(skill);
            await _context.SaveChangesAsync();

            return StatusCode(201, skill.Id);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ASkillCreateDto aSkillCreateDto)
        {
            Skill skill = await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
            #region  Check404
            if (skill == null)
                return NotFound();
            #endregion


            skill.SkillName = aSkillCreateDto.SkillName;
            skill.Percent = aSkillCreateDto.Percent;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Skill skill = await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);

            #region Check404
            if (skill == null)
                return NotFound();
            #endregion

            _context.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();


        }

    }
}
