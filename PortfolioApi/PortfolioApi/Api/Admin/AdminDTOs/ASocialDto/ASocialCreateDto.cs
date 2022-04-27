using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.ASocialDto
{
    public class ASocialCreateDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
    }
    public class ASocialCreateDtoValidator : AbstractValidator<ASocialCreateDto>
    {
        public ASocialCreateDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(25).NotEmpty();
            RuleFor(x => x.Icon).MaximumLength(250).NotEmpty();
            RuleFor(x => x.Link).MaximumLength(250).NotEmpty();
        }
    }
}
