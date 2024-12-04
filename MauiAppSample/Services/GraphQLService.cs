using MauiAppSample.Models;
using MauiAppSampleApi;
using StrawberryShake;

namespace MauiAppSample.Services
{
    internal class GraphQLService
    {
        readonly MauiAppSampleClient _client;

        public GraphQLService(MauiAppSampleClient client)
        {
            _client = client;
        }

        public async Task<AppMenu> GetAppMenusAsync()
        {
            List<AppMenuItems> appMenuItems = new List<AppMenuItems>();
            var result = await _client.GetAllAppMasters.ExecuteAsync().ConfigureAwait(false);
            result.EnsureNoErrors();
            return new AppMenu(result.Data?.AllAppMenus);
        }


        public async Task<AppMasters> GetAppsAllMastersAsync()
        {
            var result = await _client.GetAppMasters.ExecuteAsync().ConfigureAwait(false);
            result.EnsureNoErrors();

            var masters = result.Data.AllMasters;

            AppMasters appMasters = new AppMasters(
                masters.TicketStatusTables, 
                masters.ProductRepairStatusList, 
                masters.ProductTypesList);

            return appMasters;
        }

    }
}
