using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.AdminDTOs.AContactMessageDto
{
    public class AContactMessageGetDto
    {
        public List<ContactMessageItemDto> ContactMessages { get; set; }
        public int TotalCount { get; set; }
    }
    public class ContactMessageItemDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

}
