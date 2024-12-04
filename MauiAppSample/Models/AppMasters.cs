using MauiAppSampleApi;

namespace MauiAppSample.Models
{
    internal class AppMasters
    {
        public List<AppMastersItem> TicketStatusList { get; private set; }

        public List<AppMastersItem> ProductRepairStatusList { get; private set; }

        public List<AppMastersItem> ProductTypesList { get; private set; }

        public AppMasters(IReadOnlyList<IGetAppMasters_AllMasters_TicketStatusTables> ticketStatusTables, IReadOnlyList<IGetAppMasters_AllMasters_ProductRepairStatusList> productRepairStatusList1, IReadOnlyList<IGetAppMasters_AllMasters_ProductTypesList> productTypesList1)
        {
            TicketStatusList = ticketStatusTables.Select((a) => new AppMastersItem { Key = a.Key, Value = a.Value }).ToList();
            ProductRepairStatusList = productRepairStatusList1.Select((a) => new AppMastersItem { Key = a.Key, Value = a.Value }).ToList();
            ProductTypesList = productTypesList1.Select((a) => new AppMastersItem { Key = a.Key, Value = a.Value }).ToList();
        }


        //    private List<AppMastersItem> ConvertList(IList<object> list)
        //    {
        //        var convertedList = list.Select(item =>
        //        {
        //    // Use reflection to extract Key and Value properties
        //    var itemType = item.GetType();
        //    var keyProperty = itemType.GetProperty("Key");
        //    var valueProperty = itemType.GetProperty("Value");

        //    // Ensure both properties exist
        //    if (keyProperty != null && valueProperty != null)
        //    {
        //        return new AppMastersItem
        //        {
        //            Key = keyProperty.GetValue(item)?.ToString(),
        //            Value = valueProperty.GetValue(item)?.ToString()
        //        };
        //    }
        //    return null;
        //})
        //.Where(item => item != null) // Exclude nulls if any object doesn't match the expected structure
        //.ToList();

        //        return convertedList;
        //    }
        //}

        internal class AppMastersItem
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }

    }
}