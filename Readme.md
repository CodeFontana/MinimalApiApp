# MinimalApiApp

A small ASP.NET Core **Minimal API** sample for a **Person** resource backed by **SQL Server** and **Dapper** (stored procedures in `PersonDb`).

## What it demonstrates

- Minimal API route groups and endpoint mapping (`/api/v1/People`, `/api/v1/Person/...`)
- **Problem details** customization (instance, `requestId`, `traceId`)
- **Rate limiting** (fixed window) on the Person endpoints
- **OpenAPI** in development, with **Swagger UI** (try-it-out)
- A **DataAccessLibrary** with `IPersonRepository` / `PersonRepository` using Dapper against stored procedures

## Solution layout

- `MinimalApi` — host app and `Endpoints/PersonApi`
- `DataAccessLibrary` — Dapper data access and person repository
- `PersonDb` — SQL Server database project (schema and procs the API expects)

## Prerequisites

- SQL Server with a database named `PersonDb` (or adjust the connection string) and the objects from `PersonDb` published/deployed
- Update `ConnectionStrings:Default` in `MinimalApi/appsettings.json` if your server or auth differs

## Run

Start the `MinimalApi` project. In Development, use Swagger UI to call the API, or use `GET/POST/PUT/DELETE` under `/api/v1/...` as defined in `Endpoints/PersonApi.cs`.
