namespace PagePal.Data.Entities;

public class BookTitle
{
    public int Id { get; set; }

    public string ISBN { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int PublishedYear { get; set; }

    public string? Description { get; set; }

    public string? CoverImageUrl { get; set; }

    public virtual ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
