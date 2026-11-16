using PagePal.Data.Entities.Enums;

namespace PagePal.Data.Entities;

public class Reservation
{
    public int Id { get; set; }

    public int BookTitleId { get; set; }

    public virtual BookTitle BookTitle { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;

    public virtual ApplicationUser User { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int QueuePosition { get; set; }

    public ReservationStatus Status { get; set; } = ReservationStatus.Waiting;

    public DateTime? PickupDeadline { get; set; }
}
