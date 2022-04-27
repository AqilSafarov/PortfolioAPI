using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Data.Models
{
    public class TagToBlog
    {

        public int Id { get; set; }
        [ForeignKey("Tag")]

        public int TagId { get; set; }
        public Tag Tag { get; set; }
        [ForeignKey("Blog")]

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
