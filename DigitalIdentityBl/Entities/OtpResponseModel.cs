using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalIdentity.Data.Entities
{
    public class OtpResponseModel
    {
        public string? StatusMessage { get; set; }
        public string? StatusCode { get; set; }
        public bool Successful { get; set; }
    }
}
