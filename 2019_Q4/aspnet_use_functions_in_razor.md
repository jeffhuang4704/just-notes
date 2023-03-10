### Using functions within Razor page

```html
   <div id=@Model.getHeaderLevelSumId(i) class="header_row_b_item">
   <div id=@Model.getAllCompanyStatId("subfunc") class="all_summary_row_a_item"></div>

   <div id=@oneFunc.getLevelSumId(i) 
               class="function_row_b_item @Model.getValueCss(oneFunc.getLevelSum(i))">@oneFunc.getLevelSum(i)</div>
                     //** 注意這裡的 class attributes, 前半段是fixed string, 後半段是 dynamic
```

```C#
public int getLevelSum(int level)
{
	int sum = 0;
	foreach (var sf in subFunctions)
	{
		sum += sf.getLevelSum(level);
	}
	return sum;
}

public string getValueCss(int value)
{
	return value >= 0 ? string.Empty : "text-danger";
}
```

