using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PagePal.Data.Entities;

namespace PagePal.Data.Configurations;

public class LibraryRuleConfiguration : IEntityTypeConfiguration<LibraryRule>
{
    public void Configure(EntityTypeBuilder<LibraryRule> builder)
    {
        builder.HasKey(lr => lr.Id);

        builder.Property(lr => lr.DailyFineAmount)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0.50m);

        builder.Property(lr => lr.MaxActiveLoansPerUser)
            .HasDefaultValue(5);

        builder.Property(lr => lr.LoanPeriodDays)
            .HasDefaultValue(14);

        builder.Property(lr => lr.PickupWindowHours)
            .HasDefaultValue(48);

        // Seed default rule set
        builder.HasData(new LibraryRule
        {
            Id = 1,
            MaxActiveLoansPerUser = 5,
            LoanPeriodDays = 14,
            PickupWindowHours = 48,
            DailyFineAmount = 0.50m
        });
    }
}
