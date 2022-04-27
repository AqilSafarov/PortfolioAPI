using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.ATagDto;
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
    public class TagController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TagController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Tag> tag = await _context.Tags.ToListAsync();

            List<ATagGetDto> tagGetDto = _mapper.Map<List<ATagGetDto>>(tag);

            return Ok(tagGetDto);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ATagCreateDto tagCreateDto)
        {
            Tag tag = _mapper.Map<Tag>(tagCreateDto);

            await _context.AddAsync(tag);
            await _context.SaveChangesAsync();

            return StatusCode(201, tag.Id);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ATagCreateDto aTagCreateDto)
        {
            Tag tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
            #region  Check404
            if (tag == null)
                return NotFound();
            #endregion


            tag.TagName = aTagCreateDto.TagName;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Tag tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

            #region Check404
            if (tag == null)
                return NotFound();
            #endregion

            _context.Remove(tag);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}
