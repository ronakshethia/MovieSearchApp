using MauiAppSample.Models;
using MauiAppSampleApi;
using StrawberryShake;
using System.Collections.Generic;

namespace MauiAppSample.Services
{
    internal class GraphQLService : IGraphQLService
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

        public async Task<CustomerDetails> CreateCustomerAsync(CustomerDetails customer)
        {
            var result = await _client.CreateCustomer.ExecuteAsync(new CustomerTableInput 
            {
                  Id = Guid.NewGuid(),
                   Name = customer.Name,
                    PhoneNumber = customer.PhoneNumber,
                     AltPhoneNumber = customer.AltPhoneNumber
            }).ConfigureAwait(false);
            result.EnsureNoErrors();

            var customerResult = result.Data.AddNewCustomer;

            return new CustomerDetails
            {
                 Id = Guid.NewGuid(),
                CreatedOn = customerResult.CreatedOn,
                   Name = customerResult.Name,
                    PhoneNumber = customerResult.PhoneNumber,
            };
        }

        public async Task<bool> SyncCustomersAsync(List<CustomerDetails> customers)
        {
            List<CustomerTableInput> customerTableInputs = new List<CustomerTableInput>();
            customerTableInputs.AddRange(customers.Select(z => new CustomerTableInput
            {
                 Id= Guid.NewGuid(),
                 Name = z.Name,
                 AltPhoneNumber= z.PhoneNumber,
                 PhoneNumber = z.AltPhoneNumber
            }));

            var result = await _client.SyncCustomers.ExecuteAsync(customerTableInputs).ConfigureAwait(false);
            result.EnsureNoErrors();

            return result.Data.SyncCustomersFromPhone;
        }

    }
}
