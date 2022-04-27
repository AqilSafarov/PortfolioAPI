using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Client.DTOs.PortfolioUserDto
{
    public class PortUserGetDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DescAbut { get; set; }
        public string Position { get; set; }
    }
}
