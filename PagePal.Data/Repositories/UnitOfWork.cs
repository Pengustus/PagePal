using Microsoft.EntityFrameworkCore.Storage;
using PagePal.Data.Entities;

namespace PagePal.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IRepository<BookTitle>? _bookTitles;
    private IRepository<BookCopy>? _bookCopies;
    private IRepository<Loan>? _loans;
    private IRepository<Reservation>? _reservations;
    private IRepository<Notification>? _notifications;
    private IRepository<LibraryRule>? _libraryRules;
    private bool _disposed;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<BookTitle> BookTitles =>
        _bookTitles ??= new Repository<BookTitle>(_context);

    public IRepository<BookCopy> BookCopies =>
        _bookCopies ??= new Repository<BookCopy>(_context);

    public IRepository<Loan> Loans =>
        _loans ??= new Repository<Loan>(_context);

    public IRepository<Reservation> Reservations =>
        _reservations ??= new Repository<Reservation>(_context);

    public IRepository<Notification> Notifications =>
        _notifications ??= new Repository<Notification>(_context);

    public IRepository<LibraryRule> LibraryRules =>
        _libraryRules ??= new Repository<LibraryRule>(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
