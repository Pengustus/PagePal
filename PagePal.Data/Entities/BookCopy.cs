using System.ComponentModel.DataAnnotations;
using PagePal.Data.Entities.Enums;

namespace PagePal.Data.Entities;

public class BookCopy
{
    public int Id { get; set; }

    public int BookTitleId { get; set; }

    public virtual BookTitle BookTitle { get; set; } = null!;

    public string InventoryNumber { get; set; } = string.Empty;

    public string Condition { get; set; } = "Good";

    public BookCopyStatus Status { get; set; } = BookCopyStatus.Available;

    [Timestamp]
    public byte[] RowVersion { get; set; } = [];

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
