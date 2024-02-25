using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Business
{
    public class Pharmacist
    {
        [Key]
        public Guid PharmacistId { get; set; }

        [ForeignKey("Pharmacy")]
        public Guid PharmacyId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public Pharmacy Pharmacy { get; set; }
    }
}