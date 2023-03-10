## Entity Framework Query, LINQ

### Useful Official Documents

### LINQ to Entities

It has many query examples,

https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/linq-to-entities


### Query Expression Syntax Examples: Projection

https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-projection

```C#

using (AdventureWorksEntities context = new AdventureWorksEntities())
{
    var query = context.Contacts
        .GroupBy(c => c.LastName.Substring(0,1))
        .OrderBy(c => c.Key);

    foreach (IGrouping<string, Contact> group in query)
    {
        Console.WriteLine("Last names that start with the letter '{0}':",
            group.Key);
        foreach (Contact contact in group)
        {
            Console.WriteLine(contact.LastName);
        }
    }
}

```

```C#
string lastName = "Zhou";
using (AdventureWorksEntities context = new AdventureWorksEntities())
{
    ObjectSet<Contact> contacts = context.Contacts;

    var ordersQuery = from contact in contacts
                      where contact.LastName == lastName
                      select new { LastName = contact.LastName, Orders = contact.SalesOrderHeaders };

    foreach (var order in ordersQuery)
    {
        Console.WriteLine("Name: {0}", order.LastName);
        foreach (SalesOrderHeader orderInfo in order.Orders)
        {
            Console.WriteLine("Order ID: {0}, Order date: {1}, Total Due: {2}",
                orderInfo.SalesOrderID, orderInfo.OrderDate, orderInfo.TotalDue);
        }
        Console.WriteLine("");
    }
}
```