namespace PagePal.Data.Entities;

public class Loan
{
    public int Id { get; set; }

    public int BookCopyId { get; set; }

    public virtual BookCopy BookCopy { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;

    public virtual ApplicationUser User { get; set; } = null!;

    public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;

    public DateTime DueDate { get; set; }

    public DateTime? ReturnedAt { get; set; }

    public decimal FineAmount { get; set; }
}
