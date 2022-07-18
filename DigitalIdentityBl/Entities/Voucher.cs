using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DigitalIdentity.Data.Entities
{
    public class Voucher
    {
        [Key]
        //[JsonIgnore]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Designation { get; set; }

        public string? IdNumber { get; set; }

        public string? Phone { get; set; }
        
        // Foreign key to Location
        [ForeignKey("Location")]
        public Guid LocationRefId { get; set; }
        [JsonIgnore]
        public  Location? Location { get; set; }

        public Gender gender { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
