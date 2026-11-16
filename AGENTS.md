# Project: PagePal — Library Management, Book Borrowing & Waitlist System

## Tech Stack & Constraints
- **Framework:** ASP.NET Core MVC (.NET 8) with Razor Views, HTML5, CSS3, Bootstrap 5, and vanilla JavaScript.
- **Database:** MS SQL Server with Entity Framework Core Code First (Migrations + Data Seeding).
- **Authentication & Authorization:** ASP.NET Core Identity with 3 roles: `Reader`, `Librarian`, and `Admin`.
- **Security & Configuration:** Store connection strings and sensitive settings in .NET User Secrets (`dotnet user-secrets`); never hardcode secrets. Enforce secure session cookies, anti-forgery tokens, and server + client validation with clear error messages.

## Multi-Layered Architecture (Strict)
- **`PagePal.Web`:** Controllers, Razor Views, ViewModels, static assets, and custom error pages (minimum 2: e.g., `404` and `403`). Controllers MUST NOT inject `ApplicationDbContext` directly; always call interfaces from `PagePal.Services`.
- **`PagePal.Services`:** Business logic layer (`BookService`, `LoanService`, `ReservationQueueService`, `FineCalculatorService`, `NotificationService`, `ReportService`). Must remain isolated from HTTP/MVC types so it can be unit tested cleanly.
- **`PagePal.Data`:** Entities, `ApplicationDbContext`, Fluent API configurations, EF Core migrations, data seeders, and Repository / Unit of Work implementations.
- **`PagePal.Tests`:** xUnit + Moq + Coverlet unit and integration tests. Must maintain **>= 65% executable line coverage** on `PagePal.Services` (covering borrowing, queue order, deadlines, and concurrent requests).

## Domain Entities & Business Rules
1. **`ApplicationUser` (inherits `IdentityUser`):** `FullName`, `LibraryCardNumber`, `CreatedAt`.
2. **`BookTitle`:** `Id`, `ISBN`, `Title`, `Author`, `Genre`, `PublishedYear`, `Description`, `CoverImageUrl`.
3. **`BookCopy`:** `Id`, `BookTitleId`, unique `InventoryNumber`, `Condition`, `Status` (`Available`, `Borrowed`, `Reserved`, `Lost`), and `[Timestamp] byte[] RowVersion` for optimistic concurrency to prevent double-borrowing.
4. **`Loan`:** `Id`, `BookCopyId`, `UserId`, `BorrowedAt`, `DueDate`, `ReturnedAt`, `FineAmount`.
5. **`Reservation`:** `Id`, `BookTitleId`, `UserId`, `CreatedAt`, `QueuePosition` (strict FIFO order), `Status` (`Waiting`, `ReadyForPickup`, `Fulfilled`, `Expired`, `Cancelled`), `PickupDeadline`.
6. **`Notification`:** `Id`, `UserId`, `Title`, `Message`, `CreatedAt`, `IsRead`.
7. **`LibraryRule`:** `Id`, `MaxActiveLoansPerUser`, `LoanPeriodDays`, `PickupWindowHours`, `DailyFineAmount`.

## Core Domain Workflows
- Titles (`BookTitle`) represent bibliographic works; physical circulation happens strictly on `BookCopy` via unique `InventoryNumber`.
- Reservations/waitlists target a `BookTitle` in strict FIFO order (`QueuePosition`).
- Returning a `BookCopy` when an active `Waiting` reservation exists for that `BookTitle` automatically assigns the copy to the first user in line, sets the reservation to `ReadyForPickup` with a `PickupDeadline`, sets the copy status to `Reserved`, and creates a `Notification`.

## Coding Conventions
- Use `async`/`await` (`Task<T>`) for all database and service operations.
- Keep commits modular and descriptive (`feat:`, `fix:`, `docs:`, `test:`) to maintain a clean Git history.