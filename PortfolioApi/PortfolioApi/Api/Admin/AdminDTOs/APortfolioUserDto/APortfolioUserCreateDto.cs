using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.APortfolioUserDto
{
    public class APortfolioUserCreateDto
    {

        public string Image { get; set; }
        //[NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DescAbut { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public bool Freelance { get; set; }
        public int ExperienceYear { get; set; }
        public int ProjectCount { get; set; }
    }
    public class APortfolioUserCreateDtoValidator : AbstractValidator<APortfolioUserCreateDto>
    {
        public APortfolioUserCreateDtoValidator()
        {
            //RuleFor(x => x.Image).NotEmpty().WithMessage("Bos ola bilmez")
            //    .MaximumLength(250);
            RuleFor(x => x.Name).MaximumLength(25).NotEmpty();
            RuleFor(x => x.Surname).MaximumLength(25).NotEmpty();
            RuleFor(x => x.DescAbut).MaximumLength(500);
            RuleFor(x => x.Position).MaximumLength(20);
            RuleFor(x => x.Email).MaximumLength(50);
            RuleFor(x => x.Nationality).MaximumLength(50);
            RuleFor(x => x.Address).MaximumLength(100);

        }
    }
}
