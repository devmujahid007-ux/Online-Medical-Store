# MedicalStore

Medical Store Management System

A simple ASP.NET Core MVC web application for managing a small medical store. Built with .NET8 and Entity Framework Core. The project includes features for managing users, clients, sell orders, stock reporting and email notifications.

## Key features

- User management (CRUD)
- Client management
- Create and manage sell orders
- Stock and sales reports
- Email notifications (SMTP) for certain actions
- Uses SQL Server via Entity Framework Core

## Tech stack

- .NET8 (ASP.NET Core MVC)
- Entity Framework Core
- SQL Server (LocalDB / SQL Express)
- SMTP for email notifications

## Prerequisites

- .NET8 SDK (install from Microsoft .NET downloads)
- SQL Server (SQL Express or LocalDB are fine for development)
- (optional) Visual Studio2022/2023 or VS Code with the C# extension
- EF Core CLI (dotnet-ef) for applying migrations

## How to run this project (complete setup)

This section contains step-by-step instructions to get the application running locally.

1. Clone the repository

 - git clone <repo-url>
 - cd into the project folder that contains the `.csproj` file (for example `MedicalStore`)

2. Install required SDKs and tools

 - Install .NET8 SDK: https://dotnet.microsoft.com/download
 - (Optional) Install Visual Studio2022/2023 with ASP.NET and web development workload, or install VS Code + C# extension
 - Install EF Core CLI tool (used to add/apply migrations):

 - `dotnet tool install --global dotnet-ef`

3. Configure the database connection

 - Open `appsettings.json` (or `appsettings.Development.json`) and update the `ConnectionStrings:DefaultConnection` value to point to your SQL Server instance.

 - Example connection string (LocalDB):

 ```json
 "ConnectionStrings": {
 "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MedicalStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true"
 }
 ```

 - If you prefer not to store secrets in source control, use `dotnet user-secrets` or environment variables in development/production.

4. Configure email (optional for some features)

 - Email settings are read from `EmailSettings` in `appsettings.json`.
 - Example block to add/update in `appsettings.json`:

 ```json
 "EmailSettings": {
 "SmtpServer": "smtp.example.com",
 "Port":587,
 "SenderName": "MedicalStore",
 "SenderEmail": "no-reply@example.com",
 "Password": "your-email-password"
 }
 ```

 - For production, store SMTP credentials using secrets or environment variables rather than committing them.

5. Restore packages and apply EF Core migrations

 - From the project directory (where `.csproj` is located):

 - `dotnet restore`
 - Apply migrations and create the database:

 - If your project is the current directory:
 `dotnet ef database update`

 - If you need to specify the project/startup project explicitly:
 `dotnet ef database update --project <PROJECT_PATH> --startup-project <PROJECT_PATH>`

 - The repository already contains EF Core migrations in the `Migrations` folder. Running the command above will create/update the database schema.

6. Run the application

 - From the project directory:

 - `dotnet run`

 - Or open the solution/project in Visual Studio and press F5 (Debug) or Ctrl+F5 (Run without debugging).

 - By default the app will listen on a development URL printed by the console, commonly `https://localhost:5001` and/or `http://localhost:5000`.

7. Default development admin credentials

 - The project includes a development admin user in `AccountController` (for local testing):
 - Username: `admin`
 - Password: `admin123`

 - Replace or remove these before publishing to production.

8. Troubleshooting

 - If EF Core commands cannot be found, ensure `dotnet-ef` is installed and in your PATH.
 - Check the `DefaultConnection` value if the app fails to connect to the database.
 - Use the logs printed to the console and check `appsettings.Development.json` to enable detailed errors in development.

## Database

This project uses EF Core migrations. To create or apply migrations, run:

- Add migration: `dotnet ef migrations add YourMigrationName --project MedicalStore --startup-project MedicalStore`
- Apply migrations: `dotnet ef database update --project MedicalStore --startup-project MedicalStore`

If you prefer to let the app manage the database, ensure your connection string points to an available SQL Server and run the application — then apply migrations as needed.

## Default admin (development only)

The project currently contains a hard-coded development admin user in `MedicalStore/Controllers/AccountController.cs`:

- Username: `admin`
- Password: `admin123`

This is for local development/testing only. For production, move users to the database and store passwords hashed.

## Run locally

From the solution directory:

- `dotnet run --project MedicalStore`

Then open the URL shown in the console (typically `https://localhost:5001` or similar).

## Tests

(No automated tests included in this repository.)

## Contributing

- Fork the repo, create a feature branch, and open a PR.
- For security, do not commit secrets (connection strings, SMTP passwords). Use user secrets or environment variables.

## License

Include a license file if you plan to open source this project.


Notes

- This README is a short summary to include on a GitHub profile or CV. Modify and expand it to highlight your role, contributions, and screenshots when publishing to GitHub.
