using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.AContactMessageDto;
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
    public class ContactMessageController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ContactMessageController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page=1)
        {
            List<ContactMessage> contactMessage = await _context.ContactMessages.Skip((page - 1) * 8).Take(8).ToListAsync();
            AContactMessageGetDto contactMessageGetDto = new AContactMessageGetDto
            {
                ContactMessages = _mapper.Map<List<ContactMessageItemDto>>(contactMessage),
            };


            return Ok(contactMessageGetDto);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ContactMessage contactMessage = await _context.ContactMessages.FirstOrDefaultAsync(x => x.Id == id);

            #region Check404
            if (contactMessage == null)
                return NotFound();
            #endregion

            _context.Remove(contactMessage);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}
