using PortfolioApi.Api.Client.DTOs.ContactDto;
using PortfolioApi.Api.Client.DTOs.UserWithContactGetDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Vm
{
    public class VmContactWihUser
    {
        public UserWithContactGetDto GetUserWithContactDtos { get; set; }
        public ContactGetDto ContactGetDto { get; set; }
    }
}
