using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.AdminDto
{
    public class AdminLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class AdminLoginDtoValidator : AbstractValidator<AdminLoginDto>
    {
        public AdminLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull().MaximumLength(20);
            RuleFor(x => x.Password).NotNull().MaximumLength(20);
        }
    }
}
