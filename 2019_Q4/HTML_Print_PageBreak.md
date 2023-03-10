### Print HTML page (in Razor) with force page break

```HTML 
 <div class="pagebreak"></div>
 ```

 ```HTML
 // reference : GoTalent\GPortal3\Pages\PrintApplicants.cshtml
                    </div>
            </div>
        </div>
    </div>
    <div class="pagebreak"></div>
    //個人資料蒐集告知   <<----   THIS WILL BE PRINT OUT IN NEW PAGE -------------
    <div class="container smallerfont mt-5">
        <div class="row">
            <div class="col">
                <p class="text-center font-weight-bold lead">應徵者個人資料蒐集告知及聲明</p>
 ```

```JavaScript
// JavaScript
// This will invoke printer dialog box

$(document).ready(function () {
    setTimeout(function () {
        window.print();
    }, 500);
});
```

```CSS
// CSS
.pagebreak {
    page-break-before: always;
}
```
