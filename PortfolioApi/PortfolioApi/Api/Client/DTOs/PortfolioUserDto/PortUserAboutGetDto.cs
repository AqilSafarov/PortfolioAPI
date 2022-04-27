using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Client.DTOs.PortfolioUserDto
{
    public class PortUserAboutGetDto
    {

        public string Image { get; set; }
        [NotMapped]
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
}
