namespace PagePal.Data.Entities;

public class LibraryRule
{
    public int Id { get; set; }

    public int MaxActiveLoansPerUser { get; set; } = 5;

    public int LoanPeriodDays { get; set; } = 14;

    public int PickupWindowHours { get; set; } = 48;

    public decimal DailyFineAmount { get; set; } = 0.50m;
}
