### Read JSON object dynamically without declare DTO class, List<>

```C#

private List<MdnsRawObject> preParse(string jsonString)
{
    List<MdnsRawObject> rawObjects = new List<MdnsRawObject>();

    // **** cast to List<ExpandoObject>
    dynamic data = JsonConvert.DeserializeObject<List<ExpandoObject>>(jsonString, new ExpandoObjectConverter());

    foreach (var item in data)
    {
        var oneObj = new MdnsRawObject();

        {
            if (IsPropertyExist(item, "type"))
            {
                oneObj.rawData["type"] = item.type;
            }

            if (IsPropertyExist(item, "ttl"))
            {
                oneObj.rawData["ttl"] = item.ttl.ToString();
            }

            if (IsPropertyExist(item, "port"))
            {
                oneObj.rawData["port"] = item.port.ToString();
            }

            if (IsPropertyExist(item, "domain"))
            {
                oneObj.rawData["domain"] = item.domain;
            }

            if (IsPropertyExist(item, "dataA"))
            {
                oneObj.rawData["dataA"] = item.dataA;
            }

            if (IsPropertyExist(item, "dataSrv"))
            {
                oneObj.rawData["dataSrv"] = item.dataSrv;
            }

            if (IsPropertyExist(item, "dataService"))
            {
                oneObj.rawData["dataService"] = item.dataService;
            }

            if (IsPropertyExist(item, "dataTxt"))
            {
                foreach (var r in item.dataTxt)
                {
                    string txt = r;   // we need to splite to key value pair.
                    var items = txt.Split("=");
                    if (items.Length >= 2)
                    {
                        oneObj.txtRecords.Add(new KeyValuePair<string, string>(items[0], items[1]));
                    }
                }
            }
        }

        rawObjects.Add(oneObj);
    }

    return rawObjects;
}


```

### Read JSON object dynamically without declare DTO class, 

```C#
public void Parse(string jsonString)
{
    if (string.IsNullOrEmpty(jsonString))
    {
        return;
    }

    // **** cast to ExpandoObject directly
    dynamic data = JsonConvert.DeserializeObject<ExpandoObject>(jsonString, new ExpandoObjectConverter());

    gateway_mac_addr = IsPropertyExist(data, "gateway_mac_addr") ? data.gateway_mac_addr : string.Empty;
    hostname = IsPropertyExist(data, "hostname") ? data.hostname : string.Empty;
    force_overwrite_mac = IsPropertyExist(data, "force_overwrite_mac") ? data.force_overwrite_mac : string.Empty;
    mac_addr = IsPropertyExist(data, "mac_addr") ? data.mac_addr : string.Empty;
    ip_addr = IsPropertyExist(data, "gateway_mac_addr") ? data.ip_addr : string.Empty;

    if (IsPropertyExist(data, "dpi"))
    {
        int nn = 0;

        // **** cast to ExpandoObject directly
        dynamic dpiData = JsonConvert.DeserializeObject<ExpandoObject>(data.dpi, new ExpandoObjectConverter());

        dpi_host = IsPropertyExist(dpiData, "host") ? dpiData.host : string.Empty;
        dpi_ipv4 = IsPropertyExist(dpiData, "ipv4") ? dpiData.ipv4 : string.Empty;
        dpi_ipv6 = IsPropertyExist(dpiData, "ipv6") ? dpiData.ipv6 : string.Empty;
        dpi_mac = IsPropertyExist(dpiData, "mac") ? dpiData.mac : string.Empty;

        dpi_os_class_name = IsPropertyExist(dpiData, "os_class_name") ? dpiData.os_class_name : string.Empty;
        dpi_os_dev_name = IsPropertyExist(dpiData, "os_dev_name") ? dpiData.os_dev_name : string.Empty;
        dpi_os_family_name = IsPropertyExist(dpiData, "os_family_name") ? dpiData.os_family_name : string.Empty;
        dpi_os_type_name = IsPropertyExist(dpiData, "os_type_name") ? dpiData.os_type_name : string.Empty;
        dpi_os_vendor_name = IsPropertyExist(dpiData, "os_vendor_name") ? dpiData.os_vendor_name : string.Empty;

        dpi_os_class_id = IsPropertyExist(dpiData, "os_class_id") ? (int) dpiData.os_class_id : 0;
        dpi_os_dev_id = IsPropertyExist(dpiData, "os_dev_id") ? (int) dpiData.os_dev_id : 0;
        dpi_os_family_id = IsPropertyExist(dpiData, "os_family_id") ? (int) dpiData.os_family_id : 0;
        dpi_os_type_id = IsPropertyExist(dpiData, "os_type_id") ? (int) dpiData.os_type_id : 0;
        dpi_os_vendor_id = IsPropertyExist(dpiData, "os_vendor_id") ? (int) dpiData.os_vendor_id : 0;
    }
}

```

### Helper function to check if property exist
```C#
 private bool IsPropertyExist(dynamic settings, string name)
{
    if (settings is ExpandoObject)
        return ((IDictionary<string, object>)settings).ContainsKey(name);
    return settings.GetType().GetProperty(name) != null;
}
```