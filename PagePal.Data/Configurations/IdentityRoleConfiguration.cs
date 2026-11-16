using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PagePal.Data.Configurations;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public const string ReaderRoleId = "d2a01490-671e-4c74-9b57-6cbe10f0bdf1";
    public const string LibrarianRoleId = "b1c02874-9842-4f32-8419-4bce070f81d2";
    public const string AdminRoleId = "a3f5b721-3e4b-4a8a-9243-7f21e54a3219";

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = ReaderRoleId,
                Name = "Reader",
                NormalizedName = "READER",
                ConcurrencyStamp = ReaderRoleId
            },
            new IdentityRole
            {
                Id = LibrarianRoleId,
                Name = "Librarian",
                NormalizedName = "LIBRARIAN",
                ConcurrencyStamp = LibrarianRoleId
            },
            new IdentityRole
            {
                Id = AdminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = AdminRoleId
            }
        );
    }
}
