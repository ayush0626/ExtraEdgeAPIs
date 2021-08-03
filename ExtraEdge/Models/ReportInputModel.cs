using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExtraEdge.Models
{
    public class ReportInputModel
    {
        [Required]
        public string Type { get; set; }
        public int Month { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
    }
}
