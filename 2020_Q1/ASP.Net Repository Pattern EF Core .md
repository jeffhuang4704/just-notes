## ASP.NET WebAPI sample

From Pluralsight course - Building Your First API with ASP.NET Core

Last Module - Using Entity Framework Core in Our Controllers

https://app.pluralsight.com/library/courses/asp-dotnet-core-api-building-first/table-of-contents

### ICityInfoRepository

```C#
namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();

        City GetCity(int cityId, bool includePointsOfInterest);

        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);

        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);

        bool CityExists(int cityId);

        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        void DeletePointOfInterest(PointOfInterest pointOfInterest);

        bool Save();
    }
}
```

### CityInfoRepository

```C#
namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefault();
            }

            return _context.Cities
                    .Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest
               .Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest
                          .Where(p => p.CityId == cityId).ToList();
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
        }

        public void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {

        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

```

### To Register

```C#

public class Startup{

    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddScoped<ICityInfoRepository, CityInfoRepository>();
        // ...
    }

}

```


```C#
namespace CityInfo.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? 
                throw new ArgumentNullException(nameof(configuration));
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o =>
                {
                    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                });
            //.AddJsonOptions(o =>
            //{
            //    if (o.SerializerSettings.ContractResolver != null)
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver
            //                               as DefaultContractResolver;
            //        castedResolver.NamingStrategy = null;
            //    }
            //});
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
            var connectionString = _configuration["connectionStrings:cityInfoDBConnectionString"];
            services.AddDbContext<CityInfoContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            services.AddScoped<ICityInfoRepository, CityInfoRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc();             
        }
    }
}

```

### To use this service in API controller

Use Dependency Injection in constructor


```C#

public class CitiesController : ControllerBase
{
    private readonly ICityInfoRepository _cityInfoRepository;
    private readonly IMapper _mapper;

    public CitiesController(ICityInfoRepository cityInfoRepository, 
        IMapper mapper)
    {
        _cityInfoRepository = cityInfoRepository ?? 
            throw new ArgumentNullException(nameof(cityInfoRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public IActionResult GetCities()
    {
        var cityEntities = _cityInfoRepository.GetCities();

        var results = new List<CityWithoutPointsOfInterestDto>();

        foreach (var cityEntity in cityEntities)
        {
            results.Add(new CityWithoutPointsOfInterestDto
            {
                Id = cityEntity.Id,
                Description = cityEntity.Description,
                Name = cityEntity.Name
            });
        }

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult GetCity(int id, bool includePointsOfInterest=false)
    {
        var city = _cityInfoRepository.GetCity(id,includePointsOfInterest);

        if(city==null)
        {
            return NotFound();
        }

        if(includePointsOfInterest)
        {
            var cityResult = new CityDto()
            {
                Id = city.id,
                Name = city.Name,
                Description = city.Description
            };

            foreach(var poi in city.PointsOfInterest)
            {
                cityResult.PointsOfInterest.Add(
                    new PointOfInterestDto()
                    {
                        Id = poi.id,
                        Name = poi.Name,
                        Description = poi.Description
                    }
                );
            }
            return Ok(cityResult);
        }

        // defualt, no POI needed
        var cityWithoutPointsOfInterestResult = 
            new CityWithoutPointsOfInterestDto()
            {
                Id = city.id,
                Name = city.Name,
                Description = city.Description
            };

        return Ok(cityWithoutPointsOfInterestResult);
    }
}

```

```C#

public class CityWithoutPointsOfInterestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}

```

### One Coding Issue

There are a lot of mapping code here.. it's very ugly.  See AutoMapper in next section to improve it.
The code above is just a small portion of mappings. In real projects these kind of mapping will be everywhere.


### AutoMapper

The solution is AutoMapper, we use this library to help us do the dirty work (manual mapping).

https://automapper.org/

A convention-based object-object mapper. 100% organic and gluten-free. Takes out all of the fuss of mapping one object to another.

We will need to install NuGet package named "AutoMapper.Extensions.Microsoft.DependencyInjection"


```C#

public void ConfigureServices(IServiceCollection services)
{
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}

```

Define profile for the mapping.


```C#

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
        CreateMap<Entities.City, Models.CityDto>();
    }
}

public class PointOfInterestProfile : Profile
{
    public PointOfInterestProfile()
    {
        CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
        CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
        CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>()
            .ReverseMap();

    }
}

```

Use DI to inject IMapper in the constructor

```C#

public CitiesController(ICityInfoRepository cityInfoRepository, 
            IMapper mapper)
{
    _cityInfoRepository = cityInfoRepository ?? 
        throw new ArgumentNullException(nameof(cityInfoRepository));
    _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
}

```

We can then use mapper to replace old code.

```C#
[HttpGet]
public IActionResult GetCities()
{
    var cityEntities = _cityInfoRepository.GetCities();

    //var results = new List<CityWithoutPointsOfInterestDto>();

    //foreach (var cityEntity in cityEntities)
    //{
    //    results.Add(new CityWithoutPointsOfInterestDto
    //    {
    //        Id = cityEntity.Id,
    //        Description = cityEntity.Description,
    //        Name = cityEntity.Name
    //    });
    //}

    return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
}

```

The GetCity() method now looks better

```C#

[HttpGet("{id}")]
public IActionResult GetCity(int id, bool includePointsOfInterest = false)
{
    var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

    if (city == null)
    {
        return NotFound();
    } 

    if (includePointsOfInterest)
    {
        return Ok(_mapper.Map<CityDto>(city));
    }
    
    return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
}

```