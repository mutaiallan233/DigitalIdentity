using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalIdentity.Data.Entities
{
    public class Location : DigitalIdentityBase
    {
               
        public string? Name { get; set; }
        public string? AdministrativeArea { get; set; }
    }
}
