### Parse Ajax request from JavaScript client in ASP.Net Core


```C#

public class GenerateDocOption
{
    public string applicantId { get; set; }
    public string type { get; set; }
    public string offertempalte { get; set; }

    public string offerv2_type { get; set; }
    public string offerv2_type2_signon_bonus { get; set; }
    public string offerv2_type2_relocation_subsidy { get; set; }
    public string offerv2_type2_stock { get; set; }

}

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
  
	// ...........

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

	// ==>> See public class GenerateDocOption
    data: JSON.stringify({
        applicantId: currentApplicantId,
        type: "offer2",      // NEW template
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
