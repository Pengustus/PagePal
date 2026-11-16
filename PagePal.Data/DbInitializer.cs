using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PagePal.Data.Entities;

namespace PagePal.Data;

public static class DbInitializer
{
    public const string ReaderRole = "Reader";
    public const string LibrarianRole = "Librarian";
    public const string AdminRole = "Admin";

    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = [ReaderRole, LibrarianRole, AdminRole];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    public static async Task SeedDefaultRulesAsync(ApplicationDbContext context)
    {
        if (!await context.LibraryRules.AnyAsync())
        {
            context.LibraryRules.Add(new LibraryRule
            {
                MaxActiveLoansPerUser = 5,
                LoanPeriodDays = 14,
                PickupWindowHours = 48,
                DailyFineAmount = 0.50m
            });
            await context.SaveChangesAsync();
        }
    }
}
