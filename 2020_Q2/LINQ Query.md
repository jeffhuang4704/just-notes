## Use LINQ (Query syntax) to query multiple tables

Two types of query in LINQ: [Query syntax] and [Method syntax]

Query syntax and method syntax are semantically identical, but many people find query syntax simpler and easier to read. Some queries must be expressed as method calls. For example, you must use a method call to express a query that retrieves the number of elements that match a specified condition. You also must use a method call for a query that retrieves the element that has the maximum value in a source sequence.

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq

```C#
public async Task<IActionResult> OnGet()
{
    var currentUser = await _userManager.GetUserAsync(User);

    using (var context = new ApplicantDbContext(_env.WebRootPath))
    {
        var privilegeUser = context.PrivilegeUsers
            .Where(p => string.IsNullOrEmpty(p.EMail) == false)
            .Where(p => p.EMail.Equals(currentUser.Email, StringComparison.InvariantCultureIgnoreCase))
            .FirstOrDefault();

        reportLines = (from applicant in context.Applicants
                        join offer in context.OfferInfo
                        on applicant.ApplicantDataGeneralId equals offer.ApplicantDataGeneralId
                        select new ReportLineViewModel
                        {
                            ApplicantDataGeneralId = applicant.ApplicantDataGeneralId,
                            ChineseName = applicant.ChineseName,
                            ApplicantStatusStr = applicant.ApplicantStatusStr,
                            OnboardDate = offer.OnboardDate,
                            ReportLine = offer.ReportLine
                        }).OrderByDescending(r => r.OnboardDate).Take(300).ToList();
    }

    return Page();
}
```
