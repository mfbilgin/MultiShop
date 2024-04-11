namespace MultiShop.Order.Domain.Entities;

public sealed class Order : IEntity
{
    public int OrderId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = [];
}