using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Client.DTOs;
using PortfolioApi.Api.Client.DTOs.ContactDto;
using PortfolioApi.Api.Client.DTOs.ContactMessageDto;
using PortfolioApi.Api.Client.DTOs.UserWithContactGetDto;
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
            VmContactWihUser vmContactWihUser = new VmContactWihUser();

            #region UserGet

            PortfolioUser portfolioUser = await _context.PortfolioUsers.FirstOrDefaultAsync();

            vmContactWihUser.GetUserWithContactDtos = new UserWithContactGetDto
            {
                Address = portfolioUser.Address,
                Email = portfolioUser.Email,
                PhoneNumber = portfolioUser.PhoneNumber
            };


            #endregion


            #region ContactGet


            Contact contact = await _context.Contacts.FirstOrDefaultAsync();
            vmContactWihUser.ContactGetDto = new ContactGetDto
            {
                Title = contact.Title,
                Desc = contact.Desc,
            };



            #endregion
            return Ok(vmContactWihUser);


        }


        [HttpPost]
        public IActionResult SendMessage(MessageCreateDto messageCreateDto)
        {
            ContactMessage contactMessage = _mapper.Map<ContactMessage>(messageCreateDto);

            _context.ContactMessages.Add(contactMessage);
            _context.SaveChanges();

            return Ok(201);

        }
    }
}
