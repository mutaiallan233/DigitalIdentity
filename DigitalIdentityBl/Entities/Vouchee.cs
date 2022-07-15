using DigitalIdentity.Data;
using DigitalIdentity.Data.Databases.Contexts;
using DigitalIdentity.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalIdentityBl.Models
{
    public class Vouchee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }

        public string? MiddleName { get; set; }
        //TODO-FIND HOW TO ADD A LIST INTO A DATABASE
        public string? ParentIds { get; set; }
        // Foreign key to voucherid
        [Required]
        [ForeignKey("VoucherContext")]
        public Guid VoucherRefId { get; set; }
        public VoucherContext? VoucherContext { get; set; }

        [Required]

        public string? PhotoUrl { get; set; }

        public string? Voice { get; set; }
        [Required]

        public string? Nationality { get; set; }
        [Required]

        public DateTime Dob { get; set; }
        [Required]
        public Gender gender { get; set; }

    }
}
