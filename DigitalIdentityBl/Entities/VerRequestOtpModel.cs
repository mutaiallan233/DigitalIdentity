using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.Data.Entities
{
    public class VerRequestOtpModel : BaseOtpModel
    {
        
        [Required]
        public string? Operation { get; set; }
        [Required]
        public string? Source { get; set; }
        [Required]
        public string? Otp { get; set; }
    }
}
