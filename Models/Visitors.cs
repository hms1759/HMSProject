using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMgt.Models
{
    public class Visitors
    {
        [Key]
        public int VisitorId { get; set; }
        public string VisitorName { get; set; }
        public string VisitorEmail { get; set; }
        public string VisitorAddress { get; set; }
        public string Occupation { get; set; }
        public string VisitorPassword { get; set; }

    }
}
