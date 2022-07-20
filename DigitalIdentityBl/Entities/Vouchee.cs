using DigitalIdentity.Data;

using DigitalIdentity.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalIdentityBl.Models
{
    public class Vouchee : DigitalIdentityBase
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public string? ParentIds { get; set; }

        public string? PhotoUrl { get; set; }

        public string? Voice { get; set; }

        public string? Nationality { get; set; }

        public DateTime Dob { get; set; }

    }
}
