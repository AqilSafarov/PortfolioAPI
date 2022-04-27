using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.ASkillDto
{
    public class ASkillCreateDto
    {
        public string SkillName { get; set; }
        public string Percent { get; set; }
    }
    public class ASkillCreateDtoValidator : AbstractValidator<ASkillCreateDto>
    {
        public ASkillCreateDtoValidator()
        {
            RuleFor(x => x.SkillName)
                .MaximumLength(25).WithMessage("Maximum uzunluq 100 ola biler");
           
        }
    }
}
