using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.ATagDto
{
    public class ATagCreateDto
    {
        
        public string TagName { get; set; }
    }
    public class ATagCreateDtoValidator : AbstractValidator<ATagCreateDto>
    {
        public ATagCreateDtoValidator()
        {
            RuleFor(x => x.TagName).MaximumLength(50).NotEmpty();
        }
    }
}
