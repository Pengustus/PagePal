using Microsoft.EntityFrameworkCore.Storage;
using PagePal.Data.Entities;

namespace PagePal.Data.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<BookTitle> BookTitles { get; }
    IRepository<BookCopy> BookCopies { get; }
    IRepository<Loan> Loans { get; }
    IRepository<Reservation> Reservations { get; }
    IRepository<Notification> Notifications { get; }
    IRepository<LibraryRule> LibraryRules { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
