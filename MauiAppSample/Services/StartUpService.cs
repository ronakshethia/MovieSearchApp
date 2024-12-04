using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Services
{
    internal class StartUpService : IHostedService
    {
        private readonly IGraphQLService _graphQLService;

        public StartUpService(IGraphQLService graphQLService)
        {
            _graphQLService = graphQLService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Add OUR STARTUP SERVICE CALLS 
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
