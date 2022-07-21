using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DigitalIdentity.Data.Entities
{
    public class Voucher : DigitalIdentityBase
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Designation { get; set; }

        public string? IdNumber { get; set; }

        public string? Phone { get; set; }

        // Foreign key to Location
        [ForeignKey("LocationRefId")]
        public Guid LocationRefId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Location? Location { get; set; }

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
