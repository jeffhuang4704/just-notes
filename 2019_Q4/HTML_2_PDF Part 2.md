### Print HTML to PDF

### Library - DinkToPdf
https://github.com/rdvojmoc/DinkToPdf

```C#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SignOff.Models;
using SignOff.Utilities;

namespace SignOff.Pages
{
    public class GenerateDocumentsModel : PageModel
    {
        private IConverter _converter;
        private IHostingEnvironment _env;
        private IRazorViewEngine _viewEngine;
        private ITempDataProvider _tempDataProvider;
        private IServiceProvider _serviceProvider;

        private string uploadRootFolder { get; set; }

        // ========================================================
        // Note: to use DinktoPDF
        // 1. Install DinktoPDF Nuget package (https://github.com/rdvojmoc/DinkToPdf)
        // 2. Configure services in startup.cs
        // 3. Use DI (dependency injection) in constructor for various services
        // 4. put the "libwkhtmltox.dll" in the bin folder 
        // 5. in the Visual Studio "Solution Explorer", right click the libwhhtmltox.dll and select "copy to output"
        // 6. Run CheckAddBinPath()
        // ========================================================

        public GenerateDocumentsModel(IConverter converter, IHostingEnvironment env, IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
        {
            // need to configure service in Startup.cs. ConfigureServices()
            // For DinktoPDF
            //  services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            _converter = converter;
            _env = env;
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;

            uploadRootFolder = _env.ContentRootPath + @"\content2\upload";

            // put the "libwkhtmltox.dll" in the bin folder 
            // in the Visual Studio "Solution Explorer", right click the libwhhtmltox.dll and select "copy to output"
            CheckAddBinPath();
        }

        private void CheckAddBinPath()
        {
            // find path to 'bin' folder
            var binPath = Path.Combine(new string[] { AppDomain.CurrentDomain.BaseDirectory });
            var path = Environment.GetEnvironmentVariable("PATH") ?? "";

            // add 'bin' folder to search path if not already present
            if (!path.Split(Path.PathSeparator).Contains(binPath, StringComparer.CurrentCultureIgnoreCase))
            {
                path = string.Join(Path.PathSeparator.ToString(), new string[] { path, binPath });
                Environment.SetEnvironmentVariable("PATH", path);
            }
        }

        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPost()
        {
            OfferLetterViewModel vw = new OfferLetterViewModel();
            vw.testValue1 = "this is value1";
            vw.testValue2 = "this is value2";
            vw.testValue3 = "this is value3";

            string viewFile = "/Views/Home/Signofformv1.cshtml";

            var renderer = new RazorViewToStringRenderer(_viewEngine, _tempDataProvider, _serviceProvider);
            var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>(viewFile, vw);
            var pdfFile = _generateApplicationPDF(1, html, "Offer", "sign-off-form", "dummy-remove-later");
            return RedirectToPage("GenerateDocuments");
        }

        private string _generateApplicationPDF(int applicantId, string html, string filenamePrefix, string documentTitle, string password2PDF)
        {
            DateTime now = DateTime.Now;

            // create user folder if necessary
            {
                string userFolder = string.Format(@"{0}\user_{1}", uploadRootFolder, applicantId);
                if (Directory.Exists(userFolder) == false)
                {
                    Directory.CreateDirectory(userFolder);
                }
            }

            string filename = string.Format(@"user_{0}\{1}_{2}{3}{4}.pdf", applicantId, filenamePrefix, now.Year, now.Month.ToString("D2"), now.Day.ToString("D2"));
            string filenamePassProtected = string.Format(@"user_{0}\{1}_{2}{3}{4}_pass.pdf", applicantId, filenamePrefix, now.Year, now.Month.ToString("D2"), now.Day.ToString("D2"));
            string outputFileName = string.Format(@"{0}\{1}", uploadRootFolder, filename);
            string outputFileNamePassProtected = string.Format(@"{0}\{1}", uploadRootFolder, filenamePassProtected);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = documentTitle,
                Out = outputFileName
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "graphik", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "graphik", FontSize = 9, Line = true, Center = documentTitle }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return filename;
        }
    }
}
```
