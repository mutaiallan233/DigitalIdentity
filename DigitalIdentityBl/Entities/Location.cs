using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalIdentity.Data.Entities
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? AdministrativeArea { get; set; }
    }
}
