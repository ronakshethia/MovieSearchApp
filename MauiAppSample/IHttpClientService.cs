using System;
using System.Threading.Tasks;

namespace MauiAppSample
{
	public interface IHttpClientService
	{
        Task<T> GetAsync<T>(string requestEndpoint);
        Task<T> GetAsync<T>(string endpoint, string authorizationToken = null);
    }
}

