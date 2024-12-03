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

        public async IAsyncEnumerable<IGetAllAppMasters_AllAppMenus> GetAllMasters()
        {
            var result = await _client.GetAllAppMasters.ExecuteAsync().ConfigureAwait(false);
            result.EnsureNoErrors();

            foreach (var menus in result.Data?.AllAppMenus ?? [])
                yield return menus;
        }

    }
}
