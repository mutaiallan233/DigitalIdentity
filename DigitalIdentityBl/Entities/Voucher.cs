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
        [Required]
        public string? FirstName { get; set; }
        [Required]

        public string? LastName { get; set; }
        [Required]

        public string? Designation { get; set; }
        [Required]

        public string? IdNumber { get; set; }
        [Required]

        public string? Phone { get; set; }
        [Required]
        // Foreign key to Location
        [ForeignKey("Location")]
        public Guid LocationRefId { get; set; }
        [JsonIgnore]
        public  Location? Location { get; set; }

        [Required]
        public Gender gender { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
