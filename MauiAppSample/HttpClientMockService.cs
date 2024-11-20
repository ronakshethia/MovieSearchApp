using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample
{
    internal class HttpClientMockService : IHttpClientService
    {
        public Task<T> GetAsync<T>(string requestEndpoint)
        {
            return null;
        }

        public Task<T> GetAsync<T>(string endpoint, string authorizationToken = null)
        {
            return null;
        }
    }
}
