# Budget API

A personal budget backend for tracking shared expenses across **buildings**, **families**, **travels**, and **categories**.

Expenses never attach to four different tables. Each of those records owns an **expense scope**, and every expense belongs to that scope. Optional bank accounts let you debit a user’s balance when an expense is recorded.

---

## What you can do

- Create and manage buildings, families, travels, and categories
- Assign a **manager** to buildings, families, and travels
- Add **members** (users) to those records
- Record **expenses** against any of the four scopes
- Optionally link an expense to a **bank account**

Interactive docs are available in Swagger as soon as the API is running.

---

## Tech stack

| Piece | Choice |
|--------|--------|
| Runtime | .NET 10 |
| API | ASP.NET Core + controllers |
| CQRS | MediatR commands and queries |
| Database | SQLite + EF Core |
| Docs | Swagger UI (`/swagger`) |

---

## Architecture

The solution follows a simple clean-architecture split:

```
src/
  budget_back.Api            HTTP, Swagger, controllers
  budget_back.Application    Commands, queries, requests, responses, mappings
  budget_back.Domain         Entities and business rules
  budget_back.Infrastructure EF Core, SQLite, entity configurations
```

**Request flow**

1. A controller receives a `*Request`
2. A mapping turns it into a command or query
3. MediatR runs the handler
4. The handler uses `IBudgetDbContext`
5. A mapping turns the entity into a `*Response`

The API project never talks to EF Core types directly. Persistence is abstracted behind `IBudgetDbContext`.

---

## Domain model

```
User
 ├── BankAccount ── optional ── Expence
 └── member/manager of Building, Family, Travel

Building / Family / Travel / Category
 └── ExpenseScope (1:1)
      └── Expence (1:many, optional BankAccount)
```

| Concept | Role |
|---------|------|
| **ExpenseScope** | Shared parent for expenses. One per building, family, travel, or category. |
| **Expence** | An amount with a description. Always belongs to one scope. May debit a bank account. |
| **BankAccount** | Owned by a user. Remaining balance = initial balance minus linked expenses. |
| **Manager** | Required owner of a building, family, or travel. |
| **Users** | Extra members on building, family, or travel. |

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [EF Core tools](https://learn.microsoft.com/ef/core/cli/dotnet) (for migrations)

```powershell
dotnet tool install --global dotnet-ef
```

---

## Getting started

From the repository root:

```powershell
# Restore and build
./build.ps1

# Apply database migrations
./update.ps1

# Run the API
dotnet run --project src/budget_back.Api
```

Then open:

| | URL |
|--|-----|
| HTTP | http://localhost:5128 |
| HTTPS | https://localhost:7234 |
| **Swagger** | http://localhost:5128/swagger |

The SQLite file is created at the repo root as `budget_back.db` (see `appsettings.Development.json`).

### Helper scripts

| Script | What it does |
|--------|----------------|
| `./build.ps1` | Builds the API project |
| `./update.ps1` | Applies EF Core migrations |
| `./migrate.ps1 <Name>` | Adds a new migration in Infrastructure |

Example:

```powershell
./migrate.ps1 AddSomethingUseful
./update.ps1
```

---

## API overview

All endpoints return JSON. Create returns `201`, updates/deletes return `204`, missing records return `404`.

### Buildings — `/api/Buildings`

| Method | Route | Operation |
|--------|-------|-----------|
| GET | `/api/Buildings` | List buildings |
| GET | `/api/Buildings/{id}` | Get one building |
| POST | `/api/Buildings` | Create a building |
| PUT | `/api/Buildings/{id}` | Update a building |
| DELETE | `/api/Buildings/{id}` | Delete a building |
| POST | `/api/Buildings/{id}/users` | Add members |
| POST | `/api/Buildings/{id}/expences` | Add an expense |

**Create body**

```json
{
  "name": "Home",
  "managerId": 1,
  "description": "Main house",
  "address": "123 Main St"
}
```

### Categories — `/api/Categories`

| Method | Route | Operation |
|--------|-------|-----------|
| GET | `/api/Categories` | List categories |
| GET | `/api/Categories/{id}` | Get one category |
| POST | `/api/Categories` | Create a category |
| PUT | `/api/Categories/{id}` | Update a category |
| DELETE | `/api/Categories/{id}` | Delete a category |
| POST | `/api/Categories/{id}/expences` | Add an expense |

**Create body**

```json
{
  "name": "Food",
  "description": "Daily meals",
  "type": "expense",
  "icon": "utensils",
  "color": "#ff0000"
}
```

### Families — `/api/Families`

| Method | Route | Operation |
|--------|-------|-----------|
| GET | `/api/Families` | List families |
| GET | `/api/Families/{id}` | Get one family |
| POST | `/api/Families` | Create a family |
| PUT | `/api/Families/{id}` | Update a family |
| DELETE | `/api/Families/{id}` | Delete a family |
| POST | `/api/Families/{id}/users` | Add members |
| POST | `/api/Families/{id}/expences` | Add an expense |

**Create body**

```json
{
  "name": "Smith family",
  "managerId": 1,
  "description": "Household budget"
}
```

### Travels — `/api/Travels`

| Method | Route | Operation |
|--------|-------|-----------|
| GET | `/api/Travels` | List travels |
| GET | `/api/Travels/{id}` | Get one travel |
| POST | `/api/Travels` | Create a travel |
| PUT | `/api/Travels/{id}` | Update a travel |
| DELETE | `/api/Travels/{id}` | Delete a travel |
| POST | `/api/Travels/{id}/users` | Add members |
| POST | `/api/Travels/{id}/expences` | Add an expense |

**Create body**

```json
{
  "managerId": 1,
  "name": "Italy trip",
  "description": "Summer holiday",
  "startDate": "2026-07-01",
  "endDate": "2026-07-15"
}
```

### Shared nested routes

**Add members** (`Building`, `Family`, `Travel`)

```http
POST /api/Buildings/{id}/users
```

```json
{ "userIds": [1, 2, 3] }
```

- `200` — members added; response includes `userIds`
- `404` — parent record not found
- `400` — one or more user ids do not exist

Already-linked users are skipped.

**Add an expense** (all four resources)

```http
POST /api/Categories/{id}/expences
```

```json
{
  "description": "Hotel",
  "amount": 120.50,
  "bankAccountId": 1
}
```

`bankAccountId` is optional. Leave it out for cash or untracked spend.

- `201` — expense created
- `404` — parent record not found
- `400` — bank account id was sent but does not exist

---

## Typical workflow

1. Create a **user** in the database (there is no Users API yet).
2. Create a **building**, **family**, **travel**, or **category** with that user’s id as `managerId` where required.
3. Optionally `POST .../users` to add other members.
4. `POST .../expences` to record spend.
5. If the expense has a `bankAccountId`, that account’s remaining balance goes down.

---

## Configuration

Development connection string (`src/budget_back.Api/appsettings.Development.json`):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=../../budget_back.db"
  }
}
```

The API will not start without `ConnectionStrings:DefaultConnection`. For a local run, keep `ASPNETCORE_ENVIRONMENT=Development` (the default launch profile already does).

---

## Project map

```
budget_back/
├── migrate.ps1 / update.ps1 / build.ps1
├── budget_back.db                  SQLite database (after first update)
└── src/
    ├── budget_back.Api/
    │   └── Controllers/            Buildings, Categories, Families, Travels
    ├── budget_back.Application/
    │   ├── Abstractions/           IBudgetDbContext
    │   ├── features/               Commands and queries
    │   ├── Mappings/
    │   ├── Request/
    │   └── Response/
    ├── budget_back.Domain/
    │   └── AggregatedModels/
    └── budget_back.Infrastructure/
        ├── EntityTypeConfigurations/
        └── Migrations/
```

---

## Notes

- Table names are singular (`Building`, `Family`, `Expence`, …).
- The domain spelling is **Expence** (and `/expences` in URLs).
- Deleting a building, family, travel, or category also removes its expense scope and the expenses under it.
- There is currently no public API for **users** or **bank accounts**; those records need to exist in the database before you reference their ids.

For the live list of operations, request bodies, and status codes, use Swagger at `/swagger`.
