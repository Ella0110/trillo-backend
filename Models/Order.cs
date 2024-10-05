public class Order
{
  public int OrderId { get; set; }
  // FK
  public int? UserId { get; set; }
  // Properties
  public double? Amount { get; set; }
  public string? GuestName { get; set; }
  // Internal
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  // Relation
  public List<Booking> Bookings { get; set; } = new();
}