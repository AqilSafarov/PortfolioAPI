using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Services
{
    public interface IJwtServices
    {
        public string Generate(AppUser user, IList<string> roles);

    }
}
