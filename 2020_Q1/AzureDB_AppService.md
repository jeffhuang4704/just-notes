# Azure SQL and AppService practices

## Important Info

- [x] ADO.NET Connection String. You need to replace the correct attributes.
- [x] Change the password (in Password)
- [x] Change the ServerName (in Server) and database name (in Initial Catalog)
- [x] In EntityFramework Core 3 context, the migrations command is changed.
- [x] We need to add client's IP address in the Azure SQL Database Firewall, otherwise the connect will fail.

```
Server=tcp:gportaldb.database.windows.net,1433;Initial Catalog=gportalaccounts;Persist Security Info=False;User ID=gportaladmin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

### use SQL Management Console to connect to Azure SQL Database

### use a simple console ADO.NET program to do CRUD on the Azure SQL Database

```C#
    public void ReadData()
    {
    StringBuilder sb = new StringBuilder(1024);

         // Initialize Data Reader to null in case of an error
         SqlDataReader dr = null;

         // Create a connection
         using (SqlConnection cnn = new SqlConnection(connectionString))
         {
             // Open the connection
             cnn.Open();

             // Create command object
             string command = "select id,firstname, lastname from users";
             using (SqlCommand cmd = new SqlCommand(command, cnn))
             {
                 using (dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     while (dr.Read())
                     {
                         sb.AppendLine("id:" + dr["id"].ToString());
                         sb.AppendLine("firstname:" + dr["firstname"].ToString());
                         sb.AppendLine("lastname:" + dr["lastname"].ToString());
                         sb.AppendLine();
                     }
                 }
             }
         }

         message = sb.ToString();

    }
```

### Create a simple model class, and use the same approach (go1.bat, go2.bat)

```C#
    public class ApplicantDbContext : DbContext
    {
    public DbSet<ApplicantDataGeneral> Applicants { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            var connectionString = Utils.getAzureSQLDatabaseConnectionString();

             // Microsoft SQL Server
             optionsBuilder.UseSqlServer(connectionString);

             // MySQL (local)
             //optionsBuilder.UseMySQL("server=localhost;database=Applicants;user=dbuser1;password=novirus");
         }

    }
```

```
    // go1.bat
    dotnet ef migrations add InitialCreate1 --context -v ApplicantDbContext

    // go2.bat
    dotnet ef database update --context -v ApplicantDbContext
```

### Replace gportaldb web site to use Azure SQL Database

### upload program to Azure App Service

how to store sensitive data like SQL credential in Azure AppService?

we should not hard code credential in source code

Reference Pluralsight course,
Securing Application Secrets in ASP.NET Core
https://app.pluralsight.com/library/courses/securing-application-secrets-in-asp-net-core/table-of-contents

Securely save secret application settings for a web application

https://docs.microsoft.com/en-us/azure/key-vault/vs-secure-secret-appsettings

### EntityFramework Core 3

In EntityFramework Core 3 context, the migrations command is changed.

Entity Framework Core tools reference - .NET CLI
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet

`dotnet tool install --global dotnet-ef`

In EF Core 2 context

```
// go1.bat
dotnet ef migrations add InitialCreate1 --context -v ApplicantDbContext

// go2.bat
dotnet ef database update --context -v ApplicantDbContext
```

In EF Core 3

```
change ef to dotnet-ef

// go1.bat
dotnet dotnet-ef migrations add InitialCreate1 --context -v ApplicantDbContext

// go2.bat
dotnet dotnet-ef database update --context -v ApplicantDbContext
```

### Change ASP.NET Identity Database to Azure DB

In GPortal, the ASP.NET Identity is ApplicationDbContext (in file ApplicationDbContext.cs)

- [x] Change the connection string to Azure DB, it's in Startup.cs (in GPortal project)
- [x] If we only need to change identity db (keep applicants info in SQLite), we need to adjust go1.bat, go2.bat to only migrate/update the right dbcontext.
- [x] In Azure DB scenario, we **do not** need to change connection string like bofore when doing initialization.
- [x] Do not overrite the OnModelCreating() in class ApplicationDbContext. Otherwise you might get error during EF Core Migration.
      https://entityframework.net/knowledge-base/39798317/identityuserlogin-string---requires-a-primary-key-to-be-defined-error-while-adding-migration

```
IdentityUserLogin' requires a primary key to be defined error while adding migration
```

Comment all function of OnModelCreating() [do not overrite this function]

```C#
protected override void OnModelCreating(ModelBuilder builder)

```

```C#
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //Microsoft SQL doesn't need this !!!
        //    //SQLite doesn't need this !!!

        //    base.OnModelCreating(builder);

        //    //builder.Entity<ApplicationUser>()
        //    //    .Property(r => r.EmailConfirmed)
        //    //    .HasConversion(new BoolToZeroOneConverter<Int16>());

        //    //builder.Entity<ApplicationUser>()
        //    //   .Property(r => r.PhoneNumberConfirmed)
        //    //   .HasConversion(new BoolToZeroOneConverter<Int16>());

        //    //builder.Entity<ApplicationUser>()
        //    //   .Property(r => r.TwoFactorEnabled)
        //    //   .HasConversion(new BoolToZeroOneConverter<Int16>());

        //    //builder.Entity<ApplicationUser>()
        //    //   .Property(r => r.LockoutEnabled)
        //    //   .HasConversion(new BoolToZeroOneConverter<Int16>());
        //}
```

### Migrate existing ASP.NET Identity data to Azure

Only one [AspNetUsers] table has data, so we just need to migrate this table to Azure DB.

```
select _ from AspNetRoleClaims;
select _ from AspNetRoles;
select _ from AspNetUserClaims;
select _ from AspNetUserLogins;
select _ from AspNetUserRoles;
select _ from AspNetUsers;     // only this table has data in our ASP.NET Identity usage.
select _ from AspNetUserTokens;
```

### how to use Swap function on Azure App Service to take advantage of testing?

production / development? environment variable?

### CI/CD pipeline integration

when code is pushed into github, deploy a new build automatically?
