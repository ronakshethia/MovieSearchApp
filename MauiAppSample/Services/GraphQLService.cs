using StrawberryShake;

namespace MauiAppSample.Services
{
    internal class GraphQLService
    {
        readonly MauiAppSample _client;

        public GraphQLService(MauiAppSample client)
        {
            _client = client;
        }

        public async IAsyncEnumerable<IGetAllMasters_AllAppMenus> GetAllMasters()
        {
            var result = await _client.GetAllMasters.ExecuteAsync().ConfigureAwait(false);
            result.EnsureNoErrors();

            foreach (var menus in result.Data?.AllAppMenus ?? [])
                yield return menus;
        }

    }
}
