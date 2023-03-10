### Use Include(), ThenInclude().. Note multiple same Include(p => p.functions)

```C#
private HeadCountSubFunction getSubFunction(HeadCountDbContext context, HeadcountValueChangeRequest request)
{
    HeadCountSubFunction subFunction = null;

    var thePlan = context.plannings.Where(p => p.keyName.Equals(request.thePlanningKeyName))
                        .Include(p => p.functions).ThenInclude(mf => mf.PrivilegeUser)
                        .Include(p => p.functions).ThenInclude(mf => mf.subFunctions).ThenInclude(sf => sf.PrivilegeUser)
                        .Include(p => p.functions).ThenInclude(mf => mf.subFunctions).ThenInclude(sf => sf.headcountValues).ThenInclude(v => v.changeHistory)
                        .FirstOrDefault();

    if (thePlan != null)
    {
        var mf = thePlan.functions.Where(m => m.keyName.Equals(request.mainFuncKey)).FirstOrDefault();
        if (mf != null)
        {
            subFunction = mf.subFunctions.Where(s => s.keyName.Equals(request.subFuncKey)).FirstOrDefault();
        }
    }

    return subFunction;
}
```