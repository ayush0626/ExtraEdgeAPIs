using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraEdge.Models
{
    public class LoggingDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 LogId { get; set; }
        public DateTime TimeOfLogging { get; set; }

        public string Message { get; set; }
        public string Type { get; set; }

    }
}
