using MauiAppSampleApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Models
{
    internal class AppMenu
    {
        public List<AppMenuItems> AppMenuItems { get; private set; }

        public AppMenu(IReadOnlyList<IGetAllAppMasters_AllAppMenus> allAppMenus)
        {
            AppMenuItems = allAppMenus.Select(x=> new AppMenuItems() 
            {
                 MenuItemId = x.MenuItemId,
                  Sequence = x.Sequence,
                   MenuItemName = x.MenuItemName
            }).ToList();
        }
    }
}
