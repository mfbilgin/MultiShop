namespace MultiShop.Cargo.Entities.Concrete;

public class CargoDetail
{
    public int Id { get; set; }
    public string SenderCustomer { get; set; } = string.Empty;
    public string ReceiverCustomer { get; set; } = string.Empty;
    public int Barcode { get; set; }
    public int CargoCompanyId { get; set; }
    public CargoCompany CargoCompany { get; set; }
}