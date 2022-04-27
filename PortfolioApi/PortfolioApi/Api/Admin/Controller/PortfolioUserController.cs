using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.APortfolioUserDto;
using PortfolioApi.Data;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.Controller
{
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class PortfolioUserController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public PortfolioUserController(AppDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            PortfolioUser portfolioUser = await _context.PortfolioUsers.FirstOrDefaultAsync();

            APortfolioUserGetDto portfolioUserGetDto = _mapper.Map<APortfolioUserGetDto>(portfolioUser);

            return Ok(portfolioUserGetDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] APortfolioUserCreateDto createDto)
        {

            PortfolioUser portfolioUser = _mapper.Map<PortfolioUser>(createDto);
          

            if (createDto.ImageFile != null)
            {
                if (!(createDto.ImageFile.ContentType == "image/png" || createDto.ImageFile.ContentType == "image/jpeg" || createDto.ImageFile.ContentType == "image/gif"))
                {

                    return Conflict();
                }

                if (createDto.ImageFile.Length > 2097152)
                {

                    return Conflict();

                }

                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + createDto.ImageFile.FileName;
                string filePath = Path.Combine(_environment.WebRootPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    createDto.ImageFile.CopyTo(stream);
                }
                portfolioUser.Image = fileName;
                fileName = createDto.Image;



            }
            _context.PortfolioUsers.Add(portfolioUser);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm]APortfolioUserCreateDto aPortfolioUserCreate)
        {
            PortfolioUser portfolioUser = await _context.PortfolioUsers.FirstOrDefaultAsync(x => x.Id == id);
            #region  Check404
            if (portfolioUser == null)
                return NotFound();
            #endregion


            if (aPortfolioUserCreate.ImageFile != null)
            {
                if (!(aPortfolioUserCreate.ImageFile.ContentType == "image/png" || aPortfolioUserCreate.ImageFile.ContentType == "image/jpeg" || aPortfolioUserCreate.ImageFile.ContentType == "image/gif"))
                {

                    return Conflict();
                }

                if (aPortfolioUserCreate.ImageFile.Length > 2097152)
                {

                    return Conflict();

                }

                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + aPortfolioUserCreate.ImageFile.FileName;
                string filePath = Path.Combine(_environment.WebRootPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    aPortfolioUserCreate.ImageFile.CopyTo(stream);
                }
                portfolioUser.Image = fileName;
                fileName = aPortfolioUserCreate.Image;


            }
            portfolioUser.ImageFile = aPortfolioUserCreate.ImageFile;
            portfolioUser.Name = aPortfolioUserCreate.Name;
            portfolioUser.Surname = aPortfolioUserCreate.Surname;
            portfolioUser.DescAbut = aPortfolioUserCreate.DescAbut;
            portfolioUser.Position = aPortfolioUserCreate.Position;
            portfolioUser.Age = aPortfolioUserCreate.Age;
            portfolioUser.PhoneNumber = aPortfolioUserCreate.PhoneNumber;
            portfolioUser.Email = aPortfolioUserCreate.Email;
            portfolioUser.Nationality = aPortfolioUserCreate.Nationality;
            portfolioUser.Address = aPortfolioUserCreate.Address;
            portfolioUser.Freelance = aPortfolioUserCreate.Freelance;
            portfolioUser.ExperienceYear = aPortfolioUserCreate.ExperienceYear;
            portfolioUser.ProjectCount = aPortfolioUserCreate.ProjectCount;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            PortfolioUser portfolioUser = await _context.PortfolioUsers.FirstOrDefaultAsync(x=>x.Id==id);
            #region CheckNotFound404
            if (portfolioUser == null)
            {
                return NotFound();
            }
            #endregion

            _context.Remove(portfolioUser);
             _context.SaveChanges();

            return NoContent();

        }

    } 
   

}
