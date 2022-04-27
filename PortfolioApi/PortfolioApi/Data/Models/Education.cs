using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Data.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string StudtyArea { get; set; }
        public string NameOfEdu { get; set; }
        public string EduDesc { get; set; }
        public DateTime EduStartDate { get; set; }
        public string EduEndDate { get; set; }
    }
}
