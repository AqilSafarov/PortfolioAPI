using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.AEducationDto
{
    public class AEducationCreateDto
    {
        public string StudtyArea { get; set; }
        public string NameOfEdu { get; set; }
        public string EduDesc { get; set; }
        public DateTime EduStartDate { get; set; }
        public string EduEndDate { get; set; }
    }
    public class AEducationCreateDtoValidator : AbstractValidator<AEducationCreateDto>
    {
        public AEducationCreateDtoValidator()
        {
            RuleFor(x => x.StudtyArea).NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(100);
            RuleFor(x => x.NameOfEdu).NotEmpty().WithMessage("Bos ola bilmez")
              .MaximumLength(100);
            RuleFor(x => x.EduDesc).MaximumLength(500);
            RuleFor(x => x.EduEndDate).MaximumLength(250);

        }
    }
}
