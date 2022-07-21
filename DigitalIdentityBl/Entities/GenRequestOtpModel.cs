using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.Data.Entities
{
    public class GenRequestOtpModel : BaseOtpModel
    {
      
        [Required]
        public string? To { get; set; }
        [Required]
        public int Platform { get; set; }
        [Required]
        public string? Operation { get; set; }
        [Required]
        public string? Source { get; set; }
        [Required]
        public int NoofDigit { get; set; }
        [Required]
        public string? CustomerId { get; set; }
    }
}
