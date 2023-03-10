## EFCore 3 in Console App

### create an empty console app using DotNet 3

### install package

    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.Design
    Microsoft.EntityFrameworkCore.SqlServer

### create a manifest, use `dotnet new tool-manifest`

```
dotnet new tool-manifest
```

    when you try to install dotnet-ef CLI (in next step),
    you might see an error message.

    If you would like to create a manifest, use `dotnet new tool-manifest`, usually in the repo root directory.
    In this case, run [dotnet new tool-manifest] first before next step.
    you will see successful message like this "The template "Dotnet local tool manifest file" was created successfully."

### install EF Core CLI

    This is because the command in EFCore 2 was changed in EFCore 3. Check this link:
    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet

    This tool can either install globally or locally (default).

```
	dotnet tool install dotnet-ef
```

### add two batch files in the root package directory

    // go1.bat
    dotnet dotnet-ef migrations add InitialCreate1 --context -v ApplicantDbContext

    // go2.bat
    dotnet dotnet-ef database update --context -v ApplicantDbContext

### run go1.bat, go2.bat when needed

    if you see message like below. Make sure you have install [Microsoft.EntityFrameworkCore.Design]
    and add this line in the dbcontext source code (but this step seems weird?)

```
	using Microsoft.EntityFrameworkCore.Design;
```

```
Your startup project 'ConsoleEFCore3' doesn't reference Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work. Ensure your startup project is correct, install the package, and try again
```

### Enable EF Core (v3.1 in this case) Logging (To Observe How EF Core do SQL)

Install NuGet Package

```
Microsoft.Extensions.Logging
Microsoft.Extensions.Logging.Console
```

Setup a ILoggerFactory and init in DBContext.OnConfiguring().

```C#
public class ApplicantDbContext : DbContext
{
	public ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
		{
			builder.AddFilter("DbLoggerCategory.Database.Command.Name", LogLevel.Information).AddConsole();
		}
	);

	public DbSet<ApplicantDataGeneral> Applicants { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var cnStringAzureDB = "Server=tcp:gportaldb.database.windows.net,1433;Initial Catalog=gportalaccounts;Persist Security Info=False;User ID={ACCOUNT_HERE};Password='{PASS_HERE}';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

		// Use database directly
		//optionsBuilder.UseSqlServer(cnStringAzureDB);

		// enable output to console..
		optionsBuilder.UseLoggerFactory(loggerFactory)
			.EnableSensitiveDataLogging()
			.UseSqlServer(cnStringAzureDB);
	}
}
```

sample output

```
....
SensitiveDataLoggingEnabled
      Executed DbCommand (79ms) [Parameters=[@p0='104' (Size = 4000), @p1='1', @p2='2020-01-13T17:11:47'], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      INSERT INTO [Applicants] ([AppliedChannel], [Source], [SubmitTimestamp])
      VALUES (@p0, @p1, @p2);
      SELECT [ApplicantDataGeneralId]
      FROM [Applicants]
      WHERE @@ROWCOUNT = 1 AND [ApplicantDataGeneralId] = scope_identity();


info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 3.1.0 initialized 'ApplicantDbContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: SensitiveDataLoggingEnabled

: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (34ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [a].[ApplicantDataGeneralId], [a].[AppliedChannel], [a].[Source], [a].[SubmitTimestamp]
      FROM [Applicants] AS [a]

```
