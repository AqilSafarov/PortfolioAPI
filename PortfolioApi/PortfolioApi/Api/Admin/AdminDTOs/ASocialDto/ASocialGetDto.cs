using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.ASocialDto
{
    public class ASocialGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}
