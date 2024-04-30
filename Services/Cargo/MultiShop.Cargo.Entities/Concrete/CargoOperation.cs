﻿namespace MultiShop.Cargo.Entities.Concrete;

public class CargoOperation
{
    public int Id { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime OperationDate { get; set; }
    
}