using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.ASocialDto;
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
    public class SocialController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SocialController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Social> socials = await _context.Socials.ToListAsync();

            List<ASocialGetDto> socialGetDtos = _mapper.Map<List<ASocialGetDto>>(socials);

            return Ok(socialGetDtos);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ASocialCreateDto socialCreateDto)
        {
            Social social = _mapper.Map<Social>(socialCreateDto);

            await _context.AddAsync(social);
            await _context.SaveChangesAsync();

            return StatusCode(201, social.Id);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ASocialCreateDto aSocialCreate)
        {
            Social social = await _context.Socials.FirstOrDefaultAsync(x => x.Id == id);
            #region  Check404
            if (social == null)
                return NotFound();
            #endregion

            social.Name = aSocialCreate.Name;
            social.Icon = aSocialCreate.Icon;
            social.Link = aSocialCreate.Link;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Social social = await _context.Socials.FirstOrDefaultAsync(x => x.Id == id);

            #region Check404
            if (social == null)
                return NotFound();
            #endregion

            _context.Remove(social);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}
