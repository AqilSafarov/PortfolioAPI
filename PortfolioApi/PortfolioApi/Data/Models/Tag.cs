using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Data.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }
    }
}
