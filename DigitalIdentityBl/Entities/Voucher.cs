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
        [JsonIgnore]
        public Location? Location { get; set; }

        public Gender gender { get; set; }
        public List<Photos> PhotoUrl { get; set; }
    }
    public class Photos
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
