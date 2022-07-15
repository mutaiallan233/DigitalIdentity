using DigitalIdentity.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalIdentity.Data.Databases.Contexts
{
    public class VoucherContext : Voucher
    {
        [JsonIgnore]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
