## Entity Framework Core 3.x in Console

steps:
1. new a console
2. install NuGet package, Microsoft.EntityFrameworkCore.Sqlite
3. create a simple class, say class Applicants
4. prepare for first time migration

4.a  dotnet ef must be installed as a global or local tool, use this to install

	dotnet tool install --global dotnet-ef

	// (sample output)
	PS C:\Temp\efcore.console> dotnet tool install --global dotnet-ef
	You can invoke the tool using the following command: dotnet-ef
	Tool 'dotnet-ef' (version '3.1.6') was successfully installed.

4.b Install the latest Microsoft.EntityFrameworkCore.Design package.
	dotnet add package Microsoft.EntityFrameworkCore.Design


```C#
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace efcore.console.Models
{
    public class Applicant
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    }

    public class ApplicantDbContext: DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string sqliteFile = @"applicants.db";
            string cnString = string.Format("Data Source={0}", sqliteFile);
            optionsBuilder.UseSqlite(cnString);
        }
    } 

    public class AppDemo
    {
        public AppDemo()
        {

        }

        public void Run()
        {
            using (var context = new ApplicantDbContext())
            {
                var applicants = context.Applicants.ToList();
                foreach(var applicant in applicants)
                {
                    Console.WriteLine(string.Format("FirstName: {0}, LastName: {1}", applicant.firstName, applicant.lastName));
                }
            }
        }
    }
}

```

```
go1.bat

dotnet ef migrations add InitialCreate1 --context -v ApplicantDbContext

```

```
go2.bat

dotnet ef database update --context -v ApplicantDbContext
```