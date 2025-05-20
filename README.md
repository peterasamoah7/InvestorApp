# Investor App

An investor application for viewing Investors and Investor Commitments. 


##  Tech Stack

- **Frontend**: Next.js (React + TypeScript)
- **Backend**: ASP.NET Core Web API (.NET 8)
- **Database**: SQL Server (LocalDB or SQL Server Express)


## Prerequisites

Ensure the following are installed:

- [Node.js](https://nodejs.org/)
- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET SDK 8](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 

## Backend Setup & Run 

### 1. Open Backend in Visual Studio

- Go to `/backend`.
- Open the `.sln` file with Visual Studio.

### 2. Configure Backend

In `appsettings.json`:

```json
"ConnectionStrings": {
  "SqlConnection": "<use db connection or use default provided>",
},
"ClientHost":"<use client host url or use default provided>"
```
### 3. Configure Database

Database setup scripts can be found in the Investors.Data project. 
In Sql Server Management Studio or your SQL Server explorer execute 

- Create a database using the same name as provided or chosen in the sql connection string in appsetting.json.
- Execute `create_db_tbl.sql` to create database tables.
- Execute `load_test_data.sql` to load test data. 

Alternatively you can run `Update-Database` in Package Manager Console to run migrations. 

### 4. Run 

- Setup Investor.API as startup project and run application in Visual Studio


## Front Setup & Run 

### 1. Open Frontend in Visual Studio Code

- Go to `/frontend`.
- Open the folder using Visual Studio code.

### 2. Configure Backend

In `.env`: update API_BASE_URL to the base url for the backend

```json
API_BASE_URL=
```
### 3. Run 

- Run `npm istall`
- Run `npm run dev`
