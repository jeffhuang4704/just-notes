## Export Data to Excel File

### install package

    DocumentFormat.OpenXml

### Reference

Open XML SDK

https://github.com/OfficeDev/Open-XML-SDK

### Sample code (from GPortal)

```C#
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using GPortal2.Data;
using GPortal2.Models;
using GPortal2.Utilities;
using GPortal3.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GPortal3.Pages
{
  
    public class ExportDataV2ViewModel
    {
        public int id { get; set; }
        public string Owner { get; set; }

        public string Applicant_Status { get; set; }
        public string Interview_Date { get; set; }
        public string Position_Type { get; set; }
        public string Position_Applied { get; set; }
        public string Application_Method { get; set; }
    }

    public class ManageExportDataModel : PageModel
    {
        private IHostingEnvironment _env;
        private UserManager<ApplicationUser> _userManager;
        public PrivilegeUser privilegeUser { get; set; }
        private List<string> columnNames { get; set; }
        private List<ExportDataV2ViewModel> rawDataV2 { get; set; }
        public bool IsAllowed { get; set; }

        [BindProperty]
        public List<int> ExportFields { get; set; }
        public SortedDictionary<int, string> ExportFieldsTypes { get; set; }
        public SortedDictionary<int, string> BulkCheckboxTypes { get; set; }

        [BindProperty]
        public string exportType { get; set; }  // excel | googlesheets

        public ManageExportDataModel(UserManager<ApplicationUser> userManager, IHostingEnvironment env)
        {
            _env = env;
            _userManager = userManager;
            //rawData = new List<ExportDataV1ViewModel>();
            rawDataV2 = new List<ExportDataV2ViewModel>();
            IsAllowed = false;
        }

        
        // export to excel
        public IActionResult OnPostExport2Excel()
        {
            getRawDataV2();

            var generated_file = ExportToExcelV2(rawDataV2);
            var mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var downloadFilename = string.Format("Report_{0}.xslx", DateTime.Now.ToString("yyyyMMdd"));
            if (generated_file.LastIndexOf('\\') > 0)
            {
                downloadFilename = generated_file.Substring(generated_file.LastIndexOf('\\') + 1);
            }
            return PhysicalFile(generated_file, mimeType, downloadFilename);
        }

        private string ReplaceHexadecimalSymbols(string txt)
        {
            string r = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
            return Regex.Replace(txt, r, "", RegexOptions.Compiled);
        }

        private string ExportToExcelV2(List<ExportDataV2ViewModel> applicants)
        {
            int whichRow = 0;

            // Lets converts our object data to Datatable for a simplified logic.
            // Datatable is most easy way to deal with complex datatypes for easy reading and formatting. 
            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(applicants), (typeof(DataTable)));

            string outputFile = _env.ContentRootPath + string.Format(@"\content2\export\GoTalent_Exports_{0}.xlsx", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(outputFile, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };

                sheets.Append(sheet);

                Row headerRow = new Row();

                // header
                List<string> columns = new List<string>();
                int fieldIndex = 1;
                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    if (ExportFields.Contains(fieldIndex))
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }
                    fieldIndex += 1;
                }

                sheetData.AppendChild(headerRow);

                // all the rows..
                foreach (DataRow dsrow in table.Rows)
                {
                    Row newRow = new Row();

                    fieldIndex = 1;
                    foreach (String col in columns)
                    {
                        if (ExportFields.Contains(fieldIndex))
                        {
                            Cell cell = new Cell();
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(ReplaceHexadecimalSymbols(dsrow[col].ToString()));
                            //cell.CellValue = new CellValue(dsrow[col].ToString());
                            newRow.AppendChild(cell);
                        }
                        fieldIndex += 1;
                    }
                    sheetData.AppendChild(newRow);

                    whichRow++;
                }

                workbookPart.Workbook.Save();
            }

            return outputFile;
        }

        private void getRawDataV2()
        {
            // get all applicants IDs
            using (var context = new ApplicantDbContext(_env.WebRootPath))
            {
                var allApplicants = context.Applicants
                    .Where(a => !a.Reserved1.Equals("1"))
                    .Select(a => new
                    {
                        ApplicantDataGeneralId = a.ApplicantDataGeneralId,
                        ApplicantStatusStr = a.ApplicantStatusStr,
                        SubmitTime = a.SubmitTimestamp
                    }).OrderBy(a => a.SubmitTime).ToList();


                foreach (var oneApplicant in allApplicants)
                {
                    getApplicantReportByIdV2(context, oneApplicant.ApplicantDataGeneralId);
                }
            }
        }

        private void getApplicantReportByIdV2(ApplicantDbContext context, int applicantId)
        {
            var data = new ExportDataV2ViewModel();
            int nMatchedSpecialRuleCount = 0;

            DateTime interviewDate = DateTime.MinValue;

            ApplicantDataGeneral applicant = context.Applicants.Where(a => a.ApplicantDataGeneralId == applicantId).Include(a => a.PrivilegeUser).FirstOrDefault();
            ApplicantDataGeneralStage2 applicant2ndStage = context.Applicants2ndStage.Where(a => a.ApplicantDataGeneralId == applicantId).FirstOrDefault();
          
            data.Exclamation_Count = nMatchedSpecialRuleCount;

           
            rawDataV2.Add(data);
        }
    }
}
```

