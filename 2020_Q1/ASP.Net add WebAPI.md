## To add API capability in ASP.NET Core 3 Web Page

1. create a [Controllers] folder
2. create a controller class, like [WordsController]
3. add

```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
}

// expected:
services.AddRazorPages();
services.AddControllers();
```

4. add endpoints.MapControllers();

```C#
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
}

// expected:
  app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
```

-- fix-type test--