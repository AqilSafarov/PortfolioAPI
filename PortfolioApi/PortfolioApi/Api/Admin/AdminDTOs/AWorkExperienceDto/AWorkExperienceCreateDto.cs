using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.AWorkExperience
{
    public class AWorkExperienceCreateDto
    {
        public string ExpArea { get; set; }
        public string NameOfExp { get; set; }
        public string Desc { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class AWorkExperienceCreateDtoValidator : AbstractValidator<AWorkExperienceCreateDto>
    {
        public AWorkExperienceCreateDtoValidator()
        {
            RuleFor(x => x.ExpArea).NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(100).WithMessage("Maximum uzunluq 100 ola biler");
            RuleFor(x => x.NameOfExp).NotEmpty().WithMessage("Bos ola bilmez")
             .MaximumLength(100).WithMessage("Maximum uzunluq 100 ola biler");
            RuleFor(x => x.Desc).MaximumLength(500).WithMessage("Maximum uzunluq 500 ola biler"); ;
        }
    }
}
