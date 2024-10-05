public class Review
{
  public int ReviewId { get; set; }
  // FK
  public int? UserId { get; set; }
  public int? HotelId { get; set; }
  // Properties
  public string? Body { get; set; }
  public double? Rating { get; set; }
  // Internal
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  // Relation
  public Hotel Hotel { get; set; } = new();
}
