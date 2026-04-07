# CityPulse


**CityPulse** is a modern web platform designed to enhance urban environments through active citizen participation. It provides a bridge between residents and local authorities, allowing users to report infrastructure issues and track their resolution in real-time.

---

## Key Features

- **Issue Reporting:** Registered users can describe urban problems, select categories, and specify locations.
- **Intuitive Filtering:** Browse and filter the global report feed by category or search term.
- **Pagination:** Report feed is paginated (6 per page) for a clean browsing experience.
- **Location Management:** A hierarchical management system for Cities and Districts (Master-Detail view).
- **Categorization:** System-wide categories (e.g., Infrastructure, Lighting, Cleanliness) for better organization.
- **Status Tracking:** Progress monitoring through statuses” `Pending â†’ In Progress â†’ Resolved`.
- **Comment System:** Users can leave comments on reports.
- **Admin Area:** Dedicated administration area for managing categories and locations.
- **Glassmorphism UI:** A clean, modern interface built with Bootstrap 5 and custom glass-style CSS.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Backend | ASP.NET Core 8.0 MVC (C#) |
| Database | Microsoft SQL Server |
| ORM | Entity Framework Core |
| Frontend | Bootstrap 5, HTML5, CSS3 (Custom Glass Styles) |
| Auth | ASP.NET Core Identity |
| Testing | NUnit, EF Core InMemory |

---

## Architecture

The solution is split into four projects following a layered architecture:

```
CityPulse (solution)
CityPulse              ASP.NET Core MVC web app (controllers, views, areas)
CityPulse.Data         EF Core DbContext, entity models, migrations, seeding
CityPulse.Services     Business logic services and service models
CityPulse.Tests        NUnit unit tests (in-memory database)
```

### Layers

- **CityPulse.Data**” contains all entity models (`Report`, `Category`, `City`, `District`, `Comment`), EF Core configurations, migrations, and the `DbSeeder` that seeds roles and the default admin account on startup.
- **CityPulse.Services**” contains service interfaces (`IReportsService`, `ICategoriesService`, `ICitiesService`, `IDistrictsService`) and their implementations. All business logic lives here, keeping controllers thin.
- **CityPulse** (web project)” controllers consume services via dependency injection. Views are Razor-based with a shared `_Layout`, partial views (`_LoginPartial`, `_ValidationScriptsPartial`), and a dedicated Admin area with its own layout.
- **CityPulse.Tests**” NUnit tests using an EF Core InMemory database. Each test gets a fresh isolated database via `TestDbContextFactory`.

---

## Entity Models

| Model | Description |
|---|---|
| `Report` | Core entity” title, description, status, userId, categoryId, districtId |
| `Category` | Report type (e.g. Infrastructure, Lighting) |
| `City` | Top-level location |
| `District` | Belongs to a City; reports are filed against a district |
| `Comment` | Attached to a report by a user |

---

## Services

| Service | Methods |
|---|---|
| `ReportsService` | `CreateReport`, `GetAllReports` (search + pagination), `GetAll`, `GetReportById`, `GetReportsByUser`, `UpdateReport`, `DeleteReport` |
| `CategoriesService` | `GetAllCategories`, `CreateCategory`, `DeleteCategory` |
| `CitiesService` | `GetAllCities`, `GetCityById`, `CreateCity`, `DeleteCity` |
| `DistrictsService` | `GetAllDistricts`, `GetAllDistrictsByGroup`, `GetAllDistrictsByCity`, `CreateDistrict`, `DeleteDistrict` |

---

## Controllers & Views

| Controller | Area | Views |
|---|---|---|
| `HomeController`| Index, Info, NotFound, ServerError |
| `ReportsController` | Index, Details, Create, Edit, MySignals |
| `AdminController` | Admin |
| `CategoriesController` | Admin | Index, Create |
| `LocationsController` | Admin | Index, AddCity, AddDistrict |

---

## Validation

Validation is applied at three levels:

- **Database level**” `[Required]`, `[MaxLength]` attributes on entity models enforced by EF Core.
- **Server side**” `ModelState.IsValid` checks in all POST actions.
- **Client side**” `asp-validation-for` tag helpers and jQuery Unobtrusive Validation on all forms.

Custom error pages are configured for:
- `404 Not Found`
- `Views/Home/NotFound.cshtml`
- `500 Server Error`
- `Views/Home/ServerError.cshtml`

---

## Security

- **Authentication & Authorization**” ASP.NET Core Identity with `User` and `Administrator` roles.
- **Admin area**” protected with `[Authorize(Roles = "Administrator")]` on all admin controllers.
- **CSRF protection**” `[ValidateAntiForgeryToken]` on all POST actions; `asp-action` tag helpers automatically include anti-forgery tokens in forms.
- **XSS prevention**” Razor automatically HTML-encodes all output.
- **Parameter safety**” ownership checks ensure users can only edit/delete their own reports.

---

## Seeding

On first run, the application automatically seeds:

- **Roles:** `Administrator` and `User`
- **Admin account:** `admin@citypulse.com` / `Admin123!`
- **Sample categories:** Infrastructure, Lighting, Cleanliness, Roads, Parks
- **Sample cities & districts:** pre-populated so the app is usable immediately

---

## Unit Tests

Tests are written with **NUnit** and use an **EF Core InMemory** database so no SQL Server is required to run them. Each test creates a fresh isolated database via `TestDbContextFactory`.

### Coverage

| Service | Tests |
|---|---|
| `ReportsService` | CreateReport, status defaults, userId saving, search by title, search by description, case-insensitive search, pagination, empty results, DeleteReport, UpdateReport |
| `CategoriesService` | GetAll, GetAll empty, CreateCategory, DeleteCategory, delete only target |
| `CitiesService` | GetAll, CreateCity, DeleteCity, GetById |
| `DistrictsService` | GetAll, CreateDistrict with cityId, DeleteDistrict, GetByCity filtering |

Run all tests with:
```
dotnet test
```

---

## Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/ElenaMitkova/CityPulse.git
   cd CityPulse
   ```

2. **Configure the database connection** in `CityPulse/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=CityPulse;Trusted_Connection=True;"
   }
   ```

3. **Apply migrations** in the Package Manager Console:
   ```
   Update-Database
   ```

4. **Run the application.** The database will be seeded automatically on first launch.

5. **Default admin credentials:**
   - Email: `admin@citypulse.com`
   - Password: `Admin123!`

---

*Built by Elena Mitkova” ASP.NET Advanced Course @ SoftUni, 2026*
