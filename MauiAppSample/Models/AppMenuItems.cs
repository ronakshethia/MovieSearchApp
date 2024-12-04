using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Models
{
    internal class AppMenuItems
    {
        public Guid MenuItemId { get; set; }

        public string MenuItemName { get; set; }

        public object MenuItemImageUrl { get; set; }

        public long Sequence { get; set; }
    }
}
