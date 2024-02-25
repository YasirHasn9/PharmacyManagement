using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Business.Warehouses;

namespace Pharmacy.Business.Drugs;

public class Drug
{
    [Key] public Guid DrugId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}