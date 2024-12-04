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

        public async Task<CustomerDetails> GetCustomerDetailsByPhoneNumber(string phoneNumber)
        {
            var result = await _client.GetCustomerDetailsByMobileNumber.ExecuteAsync(phoneNumber).ConfigureAwait(false);
            var customerDetails =  result.Data.CustomerDetails;

            return new CustomerDetails
            {
                 AltPhoneNumber = customerDetails.AltPhoneNumber,
                  CreatedOn = customerDetails.CreatedOn,
                   Id = customerDetails.Id,
                    Name = customerDetails.Name,
                     PhoneNumber = phoneNumber
                     // CustomerTickets = new  List<object>().AddRange()
            };
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
