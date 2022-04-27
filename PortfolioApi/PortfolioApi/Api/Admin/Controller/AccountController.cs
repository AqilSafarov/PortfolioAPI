using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PortfolioApi.Api.Admin.AdminDTOs.AdminDto;
using PortfolioApi.Data;
using PortfolioApi.Data.Models;
using PortfolioApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.Controller
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtServices _jwtServices;

        public AccountController(IConfiguration configuration,AppDbContext context, UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IJwtServices jwtServices)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtServices = jwtServices;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Registor(AdminLoginDto adminLogin)
        {
            AppUser user = await _userManager.FindByNameAsync(adminLogin.UserName);


            #region CheckUserNotFound

            if (user == null)
            {
                return StatusCode(404);

            }
            #endregion

            #region CheckPassword
            if (!await _userManager.CheckPasswordAsync(user, adminLogin.Password))
            {
                return StatusCode(404);
            }
            #endregion

            var roleName = await _userManager.GetRolesAsync(user);
            string token = _jwtServices.Generate(user, roleName);

            return Ok(token);

        }

        //[HttpGet]

        //public async Task Test()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        UserName = "SurperAdmin"
        //    };
        //    await _userManager.CreateAsync(appUser, "admin123");
        //    await _userManager.AddToRoleAsync(appUser, "Admin");
        //}


        //[HttpGet("Test")]
        //public async Task<IActionResult> Test()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Memmber" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

        //    return Ok();
        //}
    }
}
