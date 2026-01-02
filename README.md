# eSports Tournament Management System (SaaS)

A web-based platform for managing eSports tournaments, teams, and matches. Built using **ASP.NET Core 7**, **Entity Framework Core**, **PostgreSQL**, and **Next.js** for the frontend. This system allows admins to create tournaments, manage stages and matches, and provides user registration/login functionality.

---

## Features

* **Tournament Management**: Create, edit, and manage tournaments, stages, and matches.
* **User Management**: Role-based users (Admin, Player, Viewer).
* **Match Tracking**: Track match status, scores, and results.
* **Payment Integration**: SSLCommerz sandbox integration for payments (optional).
* **Database Management**: PostgreSQL with Entity Framework Core code-first migrations.
* **Responsive UI**: Next.js frontend with dark/light mode support and form validation.

---

## Tech Stack

* **Backend**: ASP.NET Core 10, Entity Framework Core
* **Frontend**: Next.js 14, React, Tailwind CSS - Future implementation
* **Database**: PostgreSQL
* **ORM**: Entity Framework Core
* **Payment**: SSLCommerz (Sandbox)

---

## Project Structure

```
eSports-tournament-management-system-SaaS/
│
├─ DAL/                   # Data Access Layer (DbContext, Entities, Migrations)
├─ ApplicationLayer/      # ASP.NET Core Web API (Startup, Program.cs)
├─ README.md
├─ .env                   # Optional environment variables
├─ appsettings.json       # Connection strings & configuration
```

---

## Prerequisites

* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Node.js & npm](https://nodejs.org/) (for frontend, if using Next.js)
* pgAdmin (optional,for DB management)

---

## Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/sszobaer/eSports-tournament-management-system-SaaS.git
cd eSports-tournament-management-system-SaaS
```

### 2. Configure PostgreSQL
* Add the connection string in `ApplicationLayer/appsettings.json`:

```json
"ConnectionStrings": {
  "DbConn": "Host=localhost;Port=5432;Database=esports_db;Username=postgres;Password=your_password"
}
```

> **Optional**: Use a `.env` file if you prefer environment variables.

---

### 3. Apply EF Core Migrations

1. Open a terminal in the project root.
2. Run to create migration (if not already created):

```bash
dotnet ef migrations add InitialCreate --project DAL --startup-project ApplicationLayer
```

3. Apply migration to create the database and tables:

```bash
dotnet ef database update --project DAL --startup-project ApplicationLayer
```

* Verify the database in pgAdmin; tables should appear.

---

### 4. Build and Run the Application

```bash
cd ApplicationLayer
dotnet build
dotnet run
```

* The API will run on `https://localhost:5001` by default.
* Swagger/OpenAPI documentation is available at `https://localhost:5001/swagger/index.html`.

---

### 5. Frontend (Next.js)

> Optional if you have a separate frontend.

```bash
cd Frontend
npm install
npm run dev
```

* Access at `http://localhost:3000`.
* Ensure API endpoints are updated to match backend URLs.

---

## Running in Development

* Make sure PostgreSQL is running.
* Use `dotnet watch run` for hot reload in backend:

```bash
dotnet watch run --project ApplicationLayer
```

* Use `npm run dev` in the frontend for live reload.

---

## Notes

* EF Core tracks migrations in the `__EFMigrationsHistory` table.
* For a fresh start, you can drop the database in pgAdmin and run `dotnet ef database update` again.
* Ensure your SSLCommerz sandbox settings (if payment integration is used) are correct.

---

## Contributing

1. Fork the repository.
2. Create a feature branch.
3. Submit a pull request with clear description.

---

### Collaboration

This project is currently being developed in collaboration with **[Sabbir Hasan](https://github.com/Lisonnnnn)**, who is helping with many portions of the project.

---


## License

MIT License © 2026 S. S. Zobaer Ahmed
