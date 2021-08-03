using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraEdge.Models
{
    public class GeneratedReportModel
    {
        public string MobileBrandName { get; set; }
        public string CustomerName { get; set; }
        public Decimal MobileCost { get; set; }
        public Decimal MobileSellingCost { get; set; }
        public DateTime DateOfPurschsed { get; set; }
        public DateTime DateOfSell { get; set; }
        public Decimal DiscountOnSell { get; set; }
    }
}
