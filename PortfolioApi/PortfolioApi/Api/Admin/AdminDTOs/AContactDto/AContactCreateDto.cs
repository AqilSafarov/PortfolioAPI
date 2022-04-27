using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.AContactDto
{
    public class AContactCreateDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
    }
    public class AContactCreateDtoValidator : AbstractValidator<AContactCreateDto>
    {
        public AContactCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(50).WithMessage("Maximum uzunluq 25 ola biler");
            RuleFor(x => x.Desc).MaximumLength(500).WithMessage("Maximum uzunluq 500 ola biler"); ;
        }
    }
}
