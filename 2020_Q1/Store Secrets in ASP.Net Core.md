### Securing Application Secrets in ASP.NET Core

Pluralsight course - Securing Application Secrets in ASP.NET Core

https://app.pluralsight.com/library/courses/securing-application-secrets-in-asp-net-core/table-of-contents

1. open Visual Studio console (DOS Prompt)
2. run "dotnet user-secrets" in the console (open in #1)
3. goes to project's folder
4. run "dotnet user-secrets init"
5. after init, it will add <UserSecretId>...</UserSecretId> into project file
6. note that this init command only needs to run once. Other engineer get this source
	code from git do not need to run this init command again.
7. add secret into the secret manager
	"dotnet user-secrets set MySecretKeyName "it's a sercret here.."
8. we can list the secrets by "dotnet user-secrets list"
9. in Visual Studio, right click the project and select "Manager User-Secrets"
	you can see the secrets we just added

10. How to use the secret we just added
	- use dependency injection to inject "IConfiguration configuration" to constructor, like _configuration = configuration;
	- then fetch the value via "_configuration["MySecretKeyName"]"

11. for data in appsetttings.json like connection string, we can also put then in secret manager
	if the data is in nested format, we need to use different format

	we need to flatten it as followings: (note the :)
        (A colon : is used to flatten a nested hierarchy in configuration)

	dotnet user-secrets set ConnectionStrings:CustomerPortalDb "Data Source =...."

	for example in appsettings.json we usually have connection string like this

```
	"ConnectionStrings":{
		"CustomerPortalDb" : "Data Source =...."
	}
```

	
