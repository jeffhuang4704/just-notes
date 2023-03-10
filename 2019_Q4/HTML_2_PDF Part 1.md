### Print HTML to PDF

### Library - DinkToPdf
https://github.com/rdvojmoc/DinkToPdf

```C#
// GPortal3\Pages\GenerateDocuments.cshtml.cs
// Ajax API call

//  public class GenerateDocumentsModel : PageModel

public async Task<ActionResult> OnPostGenerateDoc()
{
    string type = string.Empty;
    string offerTemplateId = string.Empty;
    int applicantId = 0;

    int offerv2_type = 0;
    int offerv2_type2_signon_bonus = 0;
    int offerv2_type2_relocation_subsidy = 0;
    int offerv2_type2_stock = 0;

    //
    // fetch parmeers from post body
    //
    MemoryStream stream = new MemoryStream();
    Request.Body.CopyTo(stream);
    stream.Position = 0;

    using (StreamReader reader = new StreamReader(stream))
    {
        string requestBody = reader.ReadToEnd();
        if (requestBody.Length > 0)
        {
            var obj = JsonConvert.DeserializeObject<GenerateDocOption>(requestBody);
            if (obj != null)
            {
                type = obj.type;
                offerTemplateId = obj.offertempalte;
                applicantId = Convert2Int(obj.applicantId);

                offerv2_type = Convert2Int(obj.offerv2_type);
                offerv2_type2_signon_bonus = Convert2Int(obj.offerv2_type2_signon_bonus);
                offerv2_type2_relocation_subsidy = Convert2Int(obj.offerv2_type2_relocation_subsidy);
                offerv2_type2_stock = Convert2Int(obj.offerv2_type2_stock);
            }
        }
    }

    // check data
    bool validParameter = false;
    if (applicantId != 0 && offerTemplateViewFile.ContainsKey(offerTemplateId))
    {
        validParameter = true;
    }

    if (validParameter == false)
    {
        return new JsonResult(new
        {
            result = "fail - invalid parameters",
            type = type,
            applicantId = applicantId.ToString(),
            offertempalte = offerTemplateId
        });
    }

    //
    // 
    if (type.Equals("offer"))
    {
        // not used, use offer2 instead.
        //  check GPortal3\wwwroot\js\ManageApplicantDetails.js
    }
    else if (type.Equals("applicantform"))
    {
        // we need two places to generate applicant form
        // (1) print function in the details page, we need to generate the PDF and then call print out
        // (2) in the ManageApplicant page, user can download the PDF 
        // in the first case, we don't need to persist the generated PDF. We can put in temporary folder and have a scheduler task to cleanup
        // in the second case, we don't need to persists the generated PDF either. We just push the file to user and that's it. No need to store it.

        // we already have a zip download (pack multiple files in zip) function. 
        // check Pages\testing\DownloadMultipleFiles.cshtml.cs
    }
    else if (type.Equals("newcomerform"))
    {

    }
    else if (type.Equals("offer2"))
    {
        string storedOfferFile = string.Empty;
        string viewFile = string.Empty;
        OfferLetterViewModel vw = CreateOfferLetterViewModel(applicantId);

        //TEST for new offer template
        vw.offerv2_type = offerv2_type;
        vw.offerv2_type2_signon_bonus = offerv2_type2_signon_bonus;
        vw.offerv2_type2_relocation_subsidy = offerv2_type2_relocation_subsidy;
        vw.offerv2_type2_stock = offerv2_type2_stock;

		// see Razor_View_2_String.md (we use this to execute razor view and derive HTML string)
        var renderer = new RazorViewToStringRenderer(_viewEngine, _tempDataProvider, _serviceProvider);

        //C:\MyProjects\GPortal\Prototype\GPortal3\GPortal3\Views\Home\OfferLetterType1.cshtml
        //var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>("/Views/Home/OfferLetter.cshtml", vw);
        //var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>("/Views/Home/OfferLetterType1.cshtml", vw);
        //var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>("/Views/Home/OfferLetterType2.cshtml", vw);
        //var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>("/Views/Home/OfferLetterType3.cshtml", vw);
        //var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>("/Views/Home/OfferLetterType4.cshtml", vw);
        //var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>("/Views/Home/OfferLetterType5.cshtml", vw);
        //var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>("/Views/Home/OfferLetterType6.cshtml", vw);

        viewFile = offerTemplateViewFile[offerTemplateId];

        var html = await renderer.RenderViewToStringAsync<OfferLetterViewModel>(viewFile, vw);
        var pdfFile = _generateApplicationPDF(applicantId, html, "Offer", offerTemplateViewFileTitle[offerTemplateId], vw.ROCIDNumber);

        // example: storedOfferFile=content2/upload/user_25\Offer_20190517.pdf
        //  pdfFile format: string filename = string.Format(@"user_{0}\{1}_{2}{3}{4}.pdf",
        storedOfferFile = string.Format("content2/upload/{0}", pdfFile);

        // need to separate the EF context, we changed the data in the first query (applicant -> vw.applicant.ConvertValues2Display), 
        // which will corrupt data..
        using (var context = new ApplicantDbContext(_env.WebRootPath))
        {
            bool bNewOfferRecord = false;
            // need to save the generate file to database
            OfferInformation offerInfo = context.OfferInfo.Where(o => o.ApplicantDataGeneralId == applicantId).FirstOrDefault();

            // it is possible we will generate the offer file before we have a OfferInfo record in database.
            // in our UI, user switch to 錄取 and start to fill Section-C data and he can generate-offer. At this moment, 
            // when he clicks the GenerateOffer, there's no offerInfo yet.

            if (offerInfo == null)
            {
                bNewOfferRecord = true;
                offerInfo = new OfferInformation();
                offerInfo.ApplicantDataGeneralId = applicantId;

                // assign Offer Review to PrivilegeUser=Unassigned
                var pUser = context.PrivilegeUsers.Where(p => p.GroupName.Equals("HRBP"))
							.Where(p => p.Name.Equals("Unassigned")).FirstOrDefault();
                if (pUser != null)
                {
                    offerInfo.PrivilegeUserId = pUser.PrivilegeUserId;
                }
            }

            offerInfo.offerFile_local = storedOfferFile;
            offerInfo.offerFile_last_generation_time = DateTime.Now;
            offerInfo.offerFile_S3 = "";

            if (bNewOfferRecord)
            {
                context.OfferInfo.Add(offerInfo);
            }
            else
            {
                context.OfferInfo.Update(offerInfo);
            }

            context.SaveChanges();

            var resultObj = new
            {
                result = "ok",
                type = type,
                applicantId = applicantId.ToString(),
                file = storedOfferFile,
                timestamp = offerInfo.offerFile_last_generation_time.ToString("yyyy/MM/dd HH:mm:ss")
            };

            return new JsonResult(resultObj);
        }
    }


    return new JsonResult(new
    {
        result = "fail",
        type = type,
        applicantId = applicantId.ToString()
    });
}
```

```JavaScript

// GoTalent\GPortal3\wwwroot\js\ManageApplicantDetails.js
// make ajax call to generate PDF (offer doc)

$.ajax({
    type: "POST",
    url: "/GenerateDocuments?handler=GenerateDoc",
    beforeSend: function (xhr) {
        xhr.setRequestHeader("XSRF-TOKEN",
            $('input:hidden[name="__RequestVerificationToken"]').val());
    },
    data: JSON.stringify({
        applicantId: currentApplicantId,
        type: "offer2",      // NEW template
        // TODO: when we want to switch to V2, just hard-code this value to "v2". And we don't need offerTempalteId
        offertempalte: offerTempalteId,
        offerv2_type: offerv2_type,
        offerv2_type2_signon_bonus: offerv2_type2_signon_bonus,
        offerv2_type2_relocation_subsidy: offerv2_type2_relocation_subsidy,
        offerv2_type2_stock: offerv2_type2_stock
    }),
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (response) {
        // set progress bar to 100%
        $('#generate_doc_progress > .progress-bar').attr("style", "width: 100%");

        // cancel progress bar
        clearInterval(timerId);

        console.log("Generate Doc returns (we can fetch the file info here):");
        console.log(response);

        if (response.result == "ok") {
            $("#button_generate_offer_doc_preview").prop("disabled", false);

            //TODO: fetch the generated offer here..
            //offerReviewFile = response.file;

            // hide the progress bar
            setTimeout(function () {
                $('#generate_doc_progress').hide();
            }, 2000);

            // update generation time
            $('#offer_generation_time').text("Generation Time: " + response.timestamp);
        }
    },
    failure: function (response) {
        $('#offer_generation_time').text("Generate offer failed !");
        console.log("generate PDF ajax call failed !");
        // cancel progress bar
        clearInterval(timerId);

        alert(response);
    }
});

```

### The Razor page is MVC type

Reference: GoTalent\GPortal3\Views\Home\OfferLetterType1.cshtml

```HTML

@using GPortal2.Models
@model OfferLetterViewModel
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@{
    Layout = null;
}

@*HTML2PDF Page Break*@
@*https://www.api2pdf.com/print-page-breaks-with-wkhtmltopdf-or-headless-chrome/*@

@*office stamp images*@
@*https://gportalstorage.blob.core.windows.net/emailmedia/Offer Stamp_GEN(red).png
    https://gportalstorage.blob.core.windows.net/emailmedia/Offer Stamp_GSS(red).png
    https://gportalstorage.blob.core.windows.net/emailmedia/Offer Stamp_GTW(red).png*@


<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <!-- bootstrap -->
    @*we need to use online version otherwise the PDF conversion will fail*@
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    @*<link href="~/js/vendor/bootstrap-4.3.1-dist/css/bootstrap.css" rel="stylesheet" />*@

    <title>Offer Letter 聘任通知書_一般正職</title>
    <style>
        /*Google Font*/
        body {
            font-family: Arial, sans-serif;
            font-family: Microsoft JhengHei;

```