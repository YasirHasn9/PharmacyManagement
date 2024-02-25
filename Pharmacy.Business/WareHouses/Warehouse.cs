using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Business.Warehouses;
public class Warehouse
{
    [Key] public Guid WarehouseId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}