# CityPulse

**CityPulse** is a modern web platform designed to enhance urban environments through active citizen participation. It provides a bridge between residents and local authorities, allowing users to report infrastructure issues and track their resolution in real-time.

---

## Key Features

- **Issue Reporting:** Registered users can describe urban problems, select categories, and specify locations.
- **Intuitive Filtering:** Browse and filter the global report feed by category to see what's happening around the city.
- **Location Management:** A hierarchical management system for Cities and Districts (Master-Detail view).
- **Categorization:** System-wide categories (e.g., Infrastructure, Lighting, Cleanliness) for better organization.
- **Status Tracking:** Real-time progress monitoring through statuses (Pending -> In Progress -> Resolved).
- **Glassmorphism UI:** A clean, modern interface built with Bootstrap 5 and custom glass-style CSS.

---

## Tech Stack

- **Backend:** ASP.NET Core 8.0 MVC (C#)
- **Database:** Entity Framework Core & SQL Server
<img width="1336" height="803" alt="image" src="https://github.com/user-attachments/assets/0aac21bb-982a-4264-8910-8722bf00d4e3" />
- Frontend: Bootstrap 5, HTML5, CSS3 (Custom Glass Styles)

---

## Project Structure

- **Controllers:** Handles logic for `Reports`, `Cities`, `Districts`, and `Categories`.
- **Models:** Database entities and relationships.
- **ViewModels:** Specialized models like `LocationsViewModel` to manage complex data on a single page.
- **Views:** Responsive Razor views with specialized layouts for guests and registered users.

---

## How It Works

CityPulse uses a tiered access system to balance transparency with data security:

### Visitors (Unauthenticated)
- **View-Only Access:** Can browse the global list of reports and filter by category.
- **Information:** Can read the "How It Works" page to understand the platform's mission.

### Registered Users
- **Submit Reports:** Gain the ability to create new reports with photos and descriptions.
- **My Reports:** A dedicated dashboard to view, track, and edit **only** their own submissions.
- **Global Interaction:** View their own reports within the context of the entire city feed.

### Management & Administration
- **Locations Management:** Manage the geographical database by adding or removing Cities and Districts in one centralized view.
- **Category Control:** Create and edit the types of issues users can report.
- **Data Integrity:** Ability to oversee the entire ecosystem of reports and classifications.

---

## Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/ElenaMitkova/CityPulse.git](https://github.com/ElenaMitkova/CityPulse.git)
2. **Update the DefaultConnection in appsettings.json to point to your local SQL Server instance (if needed).**
3. **Run the following command in the Package Manager Console:**
   ```bash
     Update-Database
4. **Run the application.**

---

Elena Mitkova
