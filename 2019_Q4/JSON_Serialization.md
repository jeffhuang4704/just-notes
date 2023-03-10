### Configure JSON conversion to avoid crash
```C#
// 
//  convert objects to JSON, need to configure loop handling to avoid crash (refer to itself)
// 
public void OnGet()
{
    using (var context = new TiFileinfoDbContext(_env.ContentRootPath))
    {
        var files = context.TiFiles.Include(f => f.tags).ToList();
        filesInfoJson = JsonConvert.SerializeObject(files, Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
    }
}
```
