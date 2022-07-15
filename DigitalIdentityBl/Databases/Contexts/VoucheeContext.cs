using DigitalIdentityBl.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalIdentity.Data.Databases.Contexts
{
    public class VoucheeContext : Vouchee
    {

        
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DigitalId { get; set; }

    }

}
