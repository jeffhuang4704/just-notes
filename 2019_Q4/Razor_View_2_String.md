### Execute Razor View and fetch it's HTML output. And use it to generate PDF.

### Library - DinkToPdf
https://github.com/rdvojmoc/DinkToPdf

```C#
namespace GPortal2.Utilities
{
    //NOTES:
    //  in my testing it works for View using MVC, so we need to create Controll/View for this
    //  reference usage
    // 

    //1. in the Startup.cs
    //  //app.UseMvc();  // REMOVE
    //   app.UseMvcWithDefaultRoute();	// change to use this.

    //2. create Controller folder
    //    create a HomeController.cs,  sample below

    //    public class HomeController : Controller
    //    {
    //        public IActionResult Index()
    //        {
    //            var data = new Employee();
    //            data.FirstName = "John";
    //            data.LastName = "Doe";
    //            data.Title = "Manager";
    //            return View(data);
    //        }
    //    }

    //3. create Views folder
    //   create Views\Home folder
    //   create Index.cshtml file

    //   => use Razor syntax to render the HTML you want as usual
    //   => use Model which typically pass from Controller

    //4. Sample usage code shown below
    //public class IndexModel : PageModel
    //{
    //    private IRazorViewEngine _viewEngine;
    //    private ITempDataProvider _tempDataProvider;
    //    private IServiceProvider _serviceProvider;

    //    public IndexModel(IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
    //    {
    //        _viewEngine = viewEngine;
    //        _tempDataProvider = tempDataProvider;
    //        _serviceProvider = serviceProvider;
    //    }
    //    public async Task<IActionResult> OnGet()
    //    {
    //        var employee = new Employee();
    //        employee.FirstName = "John";
    //        employee.LastName = "Joe";
    //        employee.Title = "CTO";

    //        var renderer = new RazorViewToStringRenderer(_viewEngine, _tempDataProvider, _serviceProvider);

    //        // OK (MVC Page)
    //        var html = await renderer.RenderViewToStringAsync<Employee>("/Views/Home/Index.cshtml", employee);
    //        System.IO.File.WriteAllText(@"c:\temp\test1.html", html);

    //        return Page();
    //    }
    //}


    // source: https://github.com/aspnet/Entropy/blob/master/samples/Mvc.RenderViewToString/RazorViewToStringRenderer.cs
    // https://codeopinion.com/using-razor-in-a-console-application/
    public class RazorViewToStringRenderer
    {
        private IRazorViewEngine _viewEngine;
        private ITempDataProvider _tempDataProvider;
        private IServiceProvider _serviceProvider;

        public RazorViewToStringRenderer(
            IRazorViewEngine viewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
        }

        public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
        {
            var actionContext = GetActionContext();
            var view = FindView(actionContext, viewName);

            using (var output = new StringWriter())
            {
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    new ViewDataDictionary<TModel>(
                        metadataProvider: new EmptyModelMetadataProvider(),
                        modelState: new ModelStateDictionary())
                    {
                        Model = model
                    },
                    new TempDataDictionary(
                        actionContext.HttpContext,
                        _tempDataProvider),
                    output,
                    new HtmlHelperOptions());

                await view.RenderAsync(viewContext);

                return output.ToString();
            }
        }

        private IView FindView(ActionContext actionContext, string viewName)
        {
            var getViewResult = _viewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: true);
            if (getViewResult.Success)
            {
                return getViewResult.View;
            }

            var findViewResult = _viewEngine.FindView(actionContext, viewName, isMainPage: true);
            if (findViewResult.Success)
            {
                return findViewResult.View;
            }

            var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
            var errorMessage = string.Join(
                Environment.NewLine,
                new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations)); ;

            throw new InvalidOperationException(errorMessage);
        }

        private ActionContext GetActionContext()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.RequestServices = _serviceProvider;
            return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        }
    }
}
```