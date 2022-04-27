using FluentValidation;
using Microsoft.AspNetCore.Http;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.ABlogDto
{
    public class ABlogCreateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<Tag> Tags { get; set; }




    }

    public class ABlogCreateDtoValidator : AbstractValidator<ABlogCreateDto>
    {
        public ABlogCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bos ola bilmez")
                .MaximumLength(100).WithMessage("Maximum uzunluq 100 ola biler");
            RuleFor(x => x.Desc).NotEmpty().WithMessage("Bos ola bilmez");
            //RuleFor(x => x.Image).MaximumLength(250);

        }
    }
}
