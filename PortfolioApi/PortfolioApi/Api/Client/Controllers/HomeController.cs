using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Client.DTOs.PortfolioUserDto;
using PortfolioApi.Data;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            PortfolioUser portfolioUser = await _context.PortfolioUsers.FirstOrDefaultAsync();

            PortUserGetDto portUserGetDto = _mapper.Map<PortUserGetDto>(portfolioUser);

            return Ok(portUserGetDto);


        }
    }
}
