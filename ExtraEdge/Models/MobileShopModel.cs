using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraEdge.Models
{
    public class MobileShopModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public string MobileBrandName { get; set; }
        public string CustomerName { get; set; }
        public Decimal MobileCost { get; set; }
        public Decimal MobileSellingCost { get; set; }
        public DateTime DateOfPurschsed { get; set; }
        public DateTime DateOfSell { get; set; }
        public Decimal DiscountOnSell { get; set; }
    }
}
