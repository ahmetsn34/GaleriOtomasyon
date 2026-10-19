# Galeri Otomasyon

![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![.NET Framework 4.8](https://img.shields.io/badge/.NET_Framework-4.8-512BD4)
![Windows Forms](https://img.shields.io/badge/UI-Windows_Forms-0078D4)
![Entity Framework 6](https://img.shields.io/badge/Data-Entity_Framework_6-68217A)

A C# Windows Forms project for vehicle dealership and rental-office administration. The Turkish-language interface brings vehicle, customer, company, personnel, and financial records into one desktop workspace, with Entity Framework 6 handling database access.

## Implemented areas

| Area | Source functionality |
| --- | --- |
| Vehicles | Vehicle records, brand and fuel-type selections, photos, and model search |
| Customers and companies | Record creation, editing, search, and active/inactive status |
| Personnel | Staff records, photos, and payment history |
| Finance | Income and expense entries, cash totals, company transactions, and payment methods |
| Cheques and notes | Company-linked records and payment status tracking |
| Reminders | Reminder records with list, add, edit, and removal operations |

These features are present in the source. The current checkout needs the missing project files and a matching database before the application can be built and exercised.

## Technology

- **Desktop:** C#, Windows Forms, .NET Framework **4.8**.
- **Data:** Entity Framework **6.2.0**, an EDMX database-first model, and SQL Server.
- **Controls:** Guna.UI2.WinForms **2.0.3.5** and Guna.Charts.WinForms **1.0.4** are referenced by the project.
- **Dependencies:** Legacy NuGet `packages.config` format. Its `net481` install metadata differs from the project's actual `v4.8` target.

## Repository layout

```text
AraçKiralama2023.sln          Visual Studio solution
AraçKiralama2023/            WinForms project, forms, and App.config
yeni/Models/                EDMX model and generated entity classes
packages/                   Checked-in NuGet packages
.github/workflows/          Existing GitHub Actions configuration
```

[`Program.cs`](AraçKiralama2023/Program.cs) starts the login form. The solution contains one desktop application project; no automated test project is included.

## Build on Windows

Use **Visual Studio 2022** with the **.NET desktop development** workload, the **.NET Framework 4.8 targeting/developer pack**, and Entity Framework designer tools for the EDMX model. A modern .NET runtime alone does not provide this project's build tools or reference assemblies. See Microsoft's [developer-pack guide](https://learn.microsoft.com/en-us/dotnet/framework/install/guide-for-developers).

### Current build blockers

The repository does not yet provide a complete buildable checkout:

- The project references `AraçKiralama2023/Models/`, while the model files are stored under `yeni/Models/`. Restore the expected model layout or deliberately update the project references and EDMX generation settings.
- Referenced files under `Properties/` and image assets under `Resources/` are absent. NuGet restore does not recreate application resources or assembly/settings source files.
- The Git tree contains both an empty root file and a directory named `AraçKiralama2023`. A Windows checkout can show the conflicting file as deleted; this repository-layout issue needs repair before a clean checkout can be relied on.

After these source-layout issues have been resolved, open `AraçKiralama2023.sln` in Visual Studio, restore NuGet packages, and build the solution. The equivalent commands from a **Developer PowerShell for Visual Studio** terminal at the repository root are:

```powershell
msbuild ".\AraçKiralama2023.sln" /t:Restore /p:RestorePackagesConfig=true
msbuild ".\AraçKiralama2023.sln" /t:Build /p:Configuration=Release "/p:Platform=Any CPU"
```

The first command uses MSBuild's explicit support for `packages.config`; it requires MSBuild 16.5 or later. See the [NuGet restore reference](https://learn.microsoft.com/en-us/nuget/reference/msbuild-targets#restoring-packagereference-and-packagesconfig-projects-with-msbuild). These commands cannot resolve the missing source and resource files listed above.

## Database setup

The application expects an existing SQL Server database matching the EDMX model. This checkout includes the model but no database backup, SQL setup script, seed data, or migrations, so there is no complete one-command database setup.

1. Provide a development database with the tables, relationships, and lookup records expected by `yeni/Models/Model1.edmx`.
2. Review the Entity Framework connection entries in `AraçKiralama2023/App.config` and configure your own local SQL Server connection. The generated context uses the entry named `AracKiralama2023Entities3`.
3. Once the model is correctly included in the project, use the EDMX designer to reconcile it with the intended development database and regenerate its dependent classes if needed.
4. Build the solution and start it from Visual Studio to verify the database connection and individual forms against test data.

The generated context is database-first and throws `UnintentionalCodeFirstException` if used as Code First; it does not create the database automatically. Keep local database credentials and business records out of shared configuration. The current login form compares fixed values in source and is a demonstration login, not production authentication.

## Validation status

The existing GitHub Actions file is a generic .NET Core desktop packaging template with placeholder solution and package paths. It has not been configured to validate this .NET Framework solution. Missing source and resource files also prevent a complete build from the current checkout.

This documentation update was checked against the solution, project, forms, package manifest, and generated model. No successful clean build or database-backed runtime test is claimed.

## License

See the existing [LICENSE](LICENSE) file for the project's terms. Third-party controls and packages retain their own licensing terms.
