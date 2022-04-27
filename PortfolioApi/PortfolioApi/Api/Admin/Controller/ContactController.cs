using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.AContactDto;
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
    public class ContactController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ContactController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync();

            AContactGetDto contactGet = _mapper.Map<AContactGetDto>(contact);

            return Ok(contactGet);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AContactCreateDto contactCreateDto)
        {
            Contact contact = _mapper.Map<Contact>(contactCreateDto);

            await _context.AddAsync(contact);
            await _context.SaveChangesAsync();

            return StatusCode(201, contact.Id);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AContactCreateDto aContactCreateDto)
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            #region  Check404
            if (contact == null)
                return NotFound();
            #endregion


            contact.Title = aContactCreateDto.Title;
            contact.Desc = aContactCreateDto.Desc;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            #region Check404
            if (contact == null)
                return NotFound();
            #endregion


            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
