using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Business;

public class Pharmacy
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public int NumberOfFilledPrescriptions { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    
    public ICollection<Pharmacist> Pharmacists { get; set; }
}