using DigitalIdentity.Data;

using DigitalIdentity.Data.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalIdentityBl.Models
{
    public class Vouchee : DigitalIdentityBase
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }

        public string? MiddleName { get; set; }
        [ForeignKey("VoucherRefId")]
        public Guid VoucherRefId { get; set; }
        public Voucher? Voucher { get; set; }

        public string? Voice { get; set; }

        public string? Nationality { get; set; }

        public DateTime Dob { get; set; }
        public int DigitalId { get; set; }
        public Gender gender { get; set; }

        [NotMapped]
        public List<Photos> photos
        {
            get;
            set;
        }
        [System.Text.Json.Serialization.JsonIgnore]
        public string PhotoUrls
        {
            get
            {
                return JsonConvert.SerializeObject(photos);
            }
            set
            {
                photos = JsonConvert.DeserializeObject<List<Photos>>(value);
            }
        }
        // ignore this property completely
        [NotMapped]
        public List<Connections> Connections
        {
            get;
            set;
        }
        [System.Text.Json.Serialization.JsonIgnore]
        public string Connection
        {
            get
            {
                return JsonConvert.SerializeObject(Connections);
                // return System.Text.Json.JsonSerializer.Serialize(photos);

            }
            set
            {

                Connections = JsonConvert.DeserializeObject<List<Connections>>(value);
                //photos = System.Text.Json.JsonSerializer.Deserialize<List<Photos>>(value)!;


            }
        }

    }
}
